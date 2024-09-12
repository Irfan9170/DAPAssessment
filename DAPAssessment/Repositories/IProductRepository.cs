using DAPAssessment.Models;

namespace DAPAssessment.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
    }

}
