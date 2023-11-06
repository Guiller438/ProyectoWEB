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
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
   
            if(id == null || id == 0)
            {
                //Crear
                return View(new Company());
            }
            else
            {
                //Actualizar
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyObj);
            }
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if(ModelState.IsValid)
            {

                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "El companyo fue creado de manera correcta";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
            
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new {data = objCompanyList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(u=> u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { sucess = false, message = "Existe un error mientras se intenta eliminar el companyo" });

            }

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
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
//        string companyPath = Path.Combine(wwwRootPath, @"images\company");

//        if (!string.IsNullOrEmpty(companyVM.Company.ImageUrl))
//        {

//            var oldImagePath = Path.Combine(wwwRootPath, companyVM.Company.ImageUrl.TrimStart('\\'));

//            if (System.IO.File.Exists(oldImagePath))
//            {
//                System.IO.File.Delete(oldImagePath);
//            }

//        }
//        using (var filestream = new FileStream(Path.Combine(companyPath, fileName), FileMode.Create))
//        {
//            file.CopyTo(filestream);
//        }

//        companyVM.Company.ImageUrl = @"\images\company\" + fileName;
//    }

//    if (companyVM.Company.Id != 0)
//    {
//        _unitOfWork.Company.Add(companyVM.Company);//le decimos que es lo que tiene que agregar
//        _unitOfWork.Save();//lo agrega
//    }
//    else
//    {
//        _unitOfWork.Company.Update(companyVM.Company);//le decimos que es lo que tiene que agregar
//    }


//    TempData["success"] = "La categoria ha sido creada de manera exitosa";
//    return RedirectToAction("Index");//Nos devuelve al Index de la pagina

//}
//else
//{

//    companyVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new
//                                            SelectListItem
//    {
//        Text = u.Name,
//        Value = u.Id.ToString(),
//    });
//}
//return View(companyVM);



//public IActionResult Upsert(CompanyVM companyVM, IFormFile? file)
//{
//    if (ModelState.IsValid)
//    {
//        string wwwRootPath = _webHostEnvironment.WebRootPath;
//        if (file != null)
//        {
//            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
//            string companyPath = Path.Combine(wwwRootPath, @"images\company");

//            using (var fileStream = new FileStream(Path.Combine(companyPath, fileName), FileMode.Create))
//            {
//                file.CopyTo(fileStream);
//            }

//            companyVM.Company.ImageUrl = @"\images\company\" + fileName;
//        }
//        _unitOfWork.Company.Add(companyVM.Company);
//        _unitOfWork.Save();
//        TempData["success"] = "El companyo fue creado de manera correcta";
//        return RedirectToAction("Index");
//    }
//    else
//    {
//        companyVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
//        {
//            Text = u.Name,
//            Value = u.Id.ToString(),
//        });
//    }
//    return View();
//}
