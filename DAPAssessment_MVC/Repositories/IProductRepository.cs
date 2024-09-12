using DAPAssessment_MVC.Models;

namespace DAPAssessment_MVC.Repositories
{


    public interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task<ProductViewModel> CreateProductAsync(ProductViewModel product);
    }

}
