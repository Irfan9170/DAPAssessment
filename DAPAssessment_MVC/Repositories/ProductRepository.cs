using DAPAssessment_MVC.Models;
using DAPAssessment_MVC.Repositories;
namespace DAPAssessment_MVC.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;

        public ProductRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductViewModel>>("api/products");
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductViewModel>($"api/products/{id}");
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductViewModel>();
        }
    }

}
