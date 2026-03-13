using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";


        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = _client.PostAsJsonAsync(BasePath, model);

            if (response.Result.IsSuccessStatusCode)
                return response.Result.ReadContentAs<ProductViewModel>();
            else throw new ApplicationException($"Something went wrong calling the API: {response.Result.ReasonPhrase}");
        }

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            // Só adiciona Authorization se tiver token
            if (!string.IsNullOrWhiteSpace(token))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");

            return await response.ReadContentAs<ProductViewModel>();
        }

        public Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = _client.PutAsJson(BasePath, model);

            if (response.Result.IsSuccessStatusCode)
                return response.Result.ReadContentAs<ProductViewModel>();
            else throw new ApplicationException($"Something went wrong calling the API: {response.Result.ReasonPhrase}");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
        }
    }
}
