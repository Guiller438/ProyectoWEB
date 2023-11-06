using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyetct11.DataAccess.Data;
using Proyetct11.DataAccess.Repository;
using Proyetct11.DataAccess.Repository.IRepository;
using Proyetct11.Models;
using Proyetct11.Models.ViewModels;
using Proyetct11.Utility;

namespace Proyetct1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new
                                                       SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()
            };
            if(id == null || id == 0)
            {
                //Crear
                return View(productVM);
            }
            else
            {
                //Actualizar
                productVM.Product = _unitOfWork.Product.Get(u=>u.Id == id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl)) 
                    {
                        //delete
                        var oldImagePath = 
                          Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath)) 
                        { 
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                      file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageUrl = @"\images\product\" + fileName;
                }

                if (productVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "El producto fue creado de manera correcta";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
            }
            return View(productVM);   
        }


  

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = objProductList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u=> u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { sucess = false, message = "Existe un error mientras se intenta eliminar el producto" });

            }

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, 
                                productToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { sucess = true, message = "Eliminado Exitosamente"});
        }
        #endregion
    }
}
//if (ModelState.IsValid)
//{
//    string wwwRootPath = _webHostEnvironment.WebRootPath;
//    if (file != null)
//    {
//        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//        string productPath = Path.Combine(wwwRootPath, @"images\product");

//        if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
//        {

//            var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

//            if (System.IO.File.Exists(oldImagePath))
//            {
//                System.IO.File.Delete(oldImagePath);
//            }

//        }
//        using (var filestream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
//        {
//            file.CopyTo(filestream);
//        }

//        productVM.Product.ImageUrl = @"\images\product\" + fileName;
//    }

//    if (productVM.Product.Id != 0)
//    {
//        _unitOfWork.Product.Add(productVM.Product);//le decimos que es lo que tiene que agregar
//        _unitOfWork.Save();//lo agrega
//    }
//    else
//    {
//        _unitOfWork.Product.Update(productVM.Product);//le decimos que es lo que tiene que agregar
//    }


//    TempData["success"] = "La categoria ha sido creada de manera exitosa";
//    return RedirectToAction("Index");//Nos devuelve al Index de la pagina

//}
//else
//{

//    productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new
//                                            SelectListItem
//    {
//        Text = u.Name,
//        Value = u.Id.ToString(),
//    });
//}
//return View(productVM);



//public IActionResult Upsert(ProductVM productVM, IFormFile? file)
//{
//    if (ModelState.IsValid)
//    {
//        string wwwRootPath = _webHostEnvironment.WebRootPath;
//        if (file != null)
//        {
//            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//            string productPath = Path.Combine(wwwRootPath, @"images\product");

//            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
//            {
//                file.CopyTo(fileStream);
//            }

//            productVM.Product.ImageUrl = @"\images\product\" + fileName;
//        }
//        _unitOfWork.Product.Add(productVM.Product);
//        _unitOfWork.Save();
//        TempData["success"] = "El producto fue creado de manera correcta";
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
//        {
//            Text = u.Name,
//            Value = u.Id.ToString(),
//        });
//    }
//    return View();
//}
