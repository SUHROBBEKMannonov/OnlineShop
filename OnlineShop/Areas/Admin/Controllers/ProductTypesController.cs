using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           // var data = _db.ProductTypes.ToList();
            return View(_db.ProductTypes.ToList());
        }

        //Crreate Get Action Method

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully created";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }

        //edit Get Action Method

        public ActionResult Edit( int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var productType = _db.ProductTypes.Find(id);
            if (productType== null)
            {
                return NotFound();

            }

            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully updated";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }
        //Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();

            }

            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Details(ProductTypes productTypes)
        {
                        
                return RedirectToAction(actionName: nameof(Index));
            
          
        }
        //Delete Get Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();

            }

            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete ( int id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != productTypes.Id)
            {
                NotFound();
            }
            var productType=_db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully removed";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);

        }
    }
}
