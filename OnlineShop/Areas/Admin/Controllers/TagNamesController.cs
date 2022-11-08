using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagNamesController : Controller
    {
        private ApplicationDbContext _db;
        public TagNamesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // var data = _db.ProductTypes.ToList();
            return View(_db.TagNames.ToList());
        }

        //Crreate Get Action Method

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTag tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.TagNames.Add(tagNames);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully created";

                return RedirectToAction(actionName: nameof(Index));
            }
            return View(tagNames);
        }

        //edit Get Action Method

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();

            }

            return View(tagName);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTag tagNames)
        {
            if (ModelState.IsValid)
            {
                _db.Update(tagNames);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully updated";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(tagNames);
        }
        //Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();

            }

            return View(tagName);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(SpecialTag tagNames)
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

            var tagName = _db.TagNames.Find(id);
            if (tagName == null)
            {
                return NotFound();

            }

            return View(tagName);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SpecialTag tagName)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != tagName.Id)
            {
                NotFound();
            }
            var tagNames = _db.TagNames.Find(id);
            if (tagNames == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(tagNames);
                await _db.SaveChangesAsync();
                TempData["success"] = "Product type successfully deleted";
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(tagName);

        }
        
    }
}
