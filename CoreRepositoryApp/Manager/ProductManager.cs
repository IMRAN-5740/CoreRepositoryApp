using CoreRepositoryApp.Data;
using CoreRepositoryApp.Interfaces.Manager;
using CoreRepositoryApp.Models;
using CoreRepositoryApp.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace CoreRepositoryApp.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager(ApplicationDbContext dbContext):base(new ProductRepository(dbContext))
        {
        }
    }
}
