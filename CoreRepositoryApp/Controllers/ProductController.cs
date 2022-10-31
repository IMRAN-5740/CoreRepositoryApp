using CoreRepositoryApp.Data;
using CoreRepositoryApp.Interfaces.Manager;
using CoreRepositoryApp.Manager;
using CoreRepositoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreRepositoryApp.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        private IProductManager _manager;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            _manager = new ProductManager(_context);
        }

        public IActionResult Index()
        {
            var products = _manager.GetAll();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            string message = "";
            bool isSaved=_manager.Add(product);
            if(isSaved)
            {
                //message = "Product has been Saved Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                message = "Product has not Saved";
            }
            _context.SaveChanges();
                ModelState.Clear();
            ViewBag.Msg=message;
            return View();
        }
    }
}
