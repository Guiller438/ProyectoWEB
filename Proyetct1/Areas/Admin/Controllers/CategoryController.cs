using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyetct11.DataAccess.Data;
using Proyetct11.DataAccess.Repository;
using Proyetct11.DataAccess.Repository.IRepository;
using Proyetct11.Models;
using Proyetct11.Utility;

namespace Proyetct1.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize (Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = SD.Role_Admin)]

        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);//le decimos que es lo que tiene que agregar
                _unitOfWork.Save();//lo agrega
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
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
                _unitOfWork.Category.Update(obj);//le decimos que es lo que tiene que agregar
                _unitOfWork.Save();//lo agrega
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "La categoria ha sido eliminada de manera exitosa";
            return RedirectToAction("Index");

        }
    }
}
