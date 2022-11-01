using CoreRepositoryApp.Models;
using EF.Core.Repository.Interface.Manager;

namespace CoreRepositoryApp.Interfaces.Manager
{
    interface IProductManager :ICommonManager<Product>
    {
        Product GetById(int id);
    }
}
