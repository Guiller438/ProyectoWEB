using Microsoft.AspNetCore.Mvc;
using Proyetct1.Data;
using Proyetct1.Models;

namespace Proyetct1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDbContext _db;
        public CategoryController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "El DisplayOrder y su categoria no pueden ser el mismo");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);//le decimos que es lo que tiene que agregar
                _db.SaveChanges();//lo agrega
                TempData["success"] = "La categoria ha sido creada de manera exitosa";
                return RedirectToAction("Index");//Nos devuelve al Index de la pagina

            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);//le decimos que es lo que tiene que agregar
                _db.SaveChanges();//lo agrega
                TempData["success"] = "La categoria ha sido editada de manera exitosa";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "La categoria ha sido eliminada de manera exitosa";
            return RedirectToAction("Index");

        }
    }
}
