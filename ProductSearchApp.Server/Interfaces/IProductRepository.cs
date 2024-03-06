using ProductSearchApp.Server.Entities;

namespace ProductSearchApp.Server.Interfaces
{
    public interface IProductRepository 
    {
        List<ItemProduct> GetProduct();
        ItemProduct GetProductById(int id);
        void DeleteProductById(int id);
        void Save();
    }
}
