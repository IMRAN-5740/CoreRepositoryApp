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

        public ActionResult Edit(int id)
        {
            var product=_manager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }  
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
           bool isUpdate=_manager.Update(product);
            if(isUpdate)
            {
                return RedirectToAction(nameof(Index));

            }
           
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var product = _manager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public ActionResult Delete(int id )
        {
            var product = _manager.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            bool isDeleted = _manager.Delete(product);
            if(isDeleted)
            {
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }
    }
}
