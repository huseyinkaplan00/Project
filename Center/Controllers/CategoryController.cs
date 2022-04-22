using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAcsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Center.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {

            var CategoryValues = cm.GetList();
            return View(CategoryValues);

        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();


        }


        [HttpPost]
        public ActionResult AddCategory(Category p)
        {

            // cm.CategoryAddBL(p);
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results=categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");

            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 

                }
            }
            return View();  
        }








    }
}