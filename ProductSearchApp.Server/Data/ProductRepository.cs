using Microsoft.EntityFrameworkCore;
using ProductSearchApp.Server.Entities;
using ProductSearchApp.Server.Interfaces;

namespace ProductSearchApp.Server.Data
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private bool disposedValue;
        private readonly ProductSearchDbContext DbContext;

        public ProductRepository(ProductSearchDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ProductRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public List<ItemProduct> GetProduct()
        {
            throw new NotImplementedException();
        }

        public ItemProduct GetProductById(int id)
        {
            var itemProduct = DbContext.Products.Where(p => p.Id == id).FirstOrDefault();
            return itemProduct;
        }

        public void DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            DbContext?.SaveChanges();
        }

        
    }
}
