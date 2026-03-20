using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Model.Context;
using GeekShopping.CartAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : BaseRepository<CartVO, Cart>, ICartRepository
    {
        private readonly IBaseRepository<ProductVO, Product> _productRepository;
        private readonly IBaseRepository<CartDetailVO, CartDetail> _cartDetailRepository;
        private readonly IBaseRepository<CartHeaderVO, CartHeader> _cartHeaderRepository;

        public CartRepository(AppDbContext context, IMapper mapper,
            IBaseRepository<ProductVO, Product> productRepository,
            IBaseRepository<CartDetailVO, CartDetail> cartDetailRepository,
            IBaseRepository<CartHeaderVO, CartHeader> cartHeaderRepository)
            : base(context, mapper)
        {
            _productRepository = productRepository;
            _cartDetailRepository = cartDetailRepository;
            _cartHeaderRepository = cartHeaderRepository;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var header = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                c => c.UserId == userId);

            if (header != null)
            {
                header.CouponCode = couponCode;
                await _cartHeaderRepository.Update(header);
                return true;
            }

            return false;
        }

        public async Task<bool> ClearCart(string id)
        {
            // Buscar CartHeader (Entity) com CartDetails usando o repositório base
            var cartHeader = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                c => c.UserId == id,
                query => query.Include(c => c.CartDetails));

            if (cartHeader == null)
                return false;

            // Remover todos os CartDetails usando o repositório base
            foreach (var detail in cartHeader.CartDetails)
            {
                await _cartDetailRepository.Delete(detail.Id);
            }

            // Remover o CartHeader usando o repositório base
            await _cartHeaderRepository.Delete(cartHeader.Id);

            return true;
        }

        public async Task<CartVO> FindCartByUserId(string id)
        {
            // Buscar CartHeader (Entity) com Include usando o repositório base
            var cartHeader = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                c => c.UserId == id,
                query => query
                    .Include(c => c.CartDetails)
                    .ThenInclude(d => d.Product));

            if (cartHeader == null)
                return new CartVO();

            // Criar objeto Cart com os dados completos
            Cart cart = new()
            {
                CartHeader = cartHeader,
                CartDetails = cartHeader.CartDetails
            };

            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var header = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                c => c.UserId == userId);

            if (header != null)
            {
                header.CouponCode = null;
                await _cartHeaderRepository.Update(header);
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                // Buscar o CartDetail usando o repositório base
                var cartDetail = await _cartDetailRepository.FindById(cartDetailsId);

                if (cartDetail == null)
                    return false;

                // Remover o CartDetail usando o repositório base
                await _cartDetailRepository.Delete(cartDetailsId);

                // Verificar se ainda existem outros CartDetails
                var cartHeader = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                    c => c.Id == cartDetail.CartHeaderId,
                    query => query.Include(c => c.CartDetails));

                // Se não houver mais CartDetails, remover o CartHeader também
                if (cartHeader != null && (cartHeader.CartDetails == null || !cartHeader.CartDetails.Any()))
                {
                    await _cartHeaderRepository.Delete(cartDetail.CartHeaderId);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO vo)
        {
            Cart cart = _mapper.Map<Cart>(vo);

            // Validar se há CartDetails
            var cartDetailInput = cart.CartDetails?.FirstOrDefault();
            if (cartDetailInput == null)
                throw new ArgumentException("CartDetails não pode estar vazio");

            // Verificar se o produto existe usando o repositório base
            var product = await _productRepository.FindById(cartDetailInput.ProductId);

            if (product == null && cartDetailInput.Product != null)
            {
                // Criar o produto se não existir usando o repositório base
                await _productRepository.Create(cartDetailInput.Product);
            }

            // Buscar CartHeader (Entity) usando o repositório base
            var existingCartHeader = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (existingCartHeader == null)
            {
                // Criar novo CartHeader usando o repositório base
                var createdHeader = await _cartHeaderRepository.Create(cart.CartHeader);
                cartDetailInput.CartHeaderId = createdHeader.Id;
                cartDetailInput.Product = null;

                // Criar CartDetail usando o repositório base
                await _cartDetailRepository.Create(cartDetailInput);
            }
            else
            {
                // CartHeader já existe, buscar CartDetails com Include
                var cartHeaderWithDetails = await _cartHeaderRepository.GetFirstOrDefaultEntityAsync(
                    c => c.Id == existingCartHeader.Id,
                    query => query.Include(c => c.CartDetails));

                var existingDetail = cartHeaderWithDetails?.CartDetails?
                    .FirstOrDefault(p => p.ProductId == cartDetailInput.ProductId);

                if (existingDetail == null)
                {
                    // Produto novo no carrinho - usar repositório base
                    cartDetailInput.CartHeaderId = existingCartHeader.Id;
                    cartDetailInput.Product = null;
                    await _cartDetailRepository.Create(cartDetailInput);
                }
                else
                {
                    // Produto já existe, atualizar quantidade - usar repositório base
                    cartDetailInput.Product = null;
                    cartDetailInput.Count += existingDetail.Count;
                    cartDetailInput.Id = existingDetail.Id;
                    cartDetailInput.CartHeaderId = existingDetail.CartHeaderId;
                    await _cartDetailRepository.Update(cartDetailInput);
                }
            }

            return _mapper.Map<CartVO>(cart);
        }
    }
}
