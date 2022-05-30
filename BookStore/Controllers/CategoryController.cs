using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryservice categoryservice;
        public CategoryController(ICategoryservice _cservice)
        {
            categoryservice = _cservice;
        }
        public IActionResult Index()
        {
            Vmcatrgory vm = new Vmcatrgory();
            vm.licateogrries = categoryservice.LoadAll();
            return View("Newcateogry", vm);
           
        }
        public IActionResult save(Vmcatrgory vm)
        {
            categoryservice.Insert(vm.category);
            vm.licateogrries= categoryservice.LoadAll();
            return View("Newcateogry", vm);
        }
        public IActionResult Delete(int Id)
        {
            Vmcatrgory vm = new Vmcatrgory();

            vm.licateogrries = categoryservice.LoadAll();
            categoryservice.Delete(Id);
            return View("Newcateogry", vm);
        }
       /* public IActionResult Edit(int Id)
        {
            Vmcatrgory vm = new Vmcatrgory();
          
            vm.licateogrries = categoryservice.LoadAll(); 
            vm.category = categoryservice.Edit(Id);
            return View("Newcateogry", vm);
        }*/
        public IActionResult Update(Vmcatrgory vm)
        {

            categoryservice.update(vm.category);
            vm.licateogrries = categoryservice.LoadAll();
            return View("Newcateogry", vm);
        }
        public IActionResult EditAjax(int Id)
        {
            Category cat = new Category();
            cat = categoryservice.Edit(Id);
            return Json(cat);
        }
    }
}
