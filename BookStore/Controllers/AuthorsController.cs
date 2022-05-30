using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthorSevice authorSevice;
        INationalityService nService;
        public AuthorsController(IAuthorSevice _authorSevice ,INationalityService _nService)
        {

           authorSevice = _authorSevice;
            nService = _nService;
        }
        public IActionResult Index()
         {
            Vmauthoers vm = new Vmauthoers();
          vm.liauthors=  authorSevice.loadAll();
            vm.liationalities = nService.LoadAll();
            

            //Vmauthoers vm = new Vmauthoers();

            return View("Newauthors",vm);
        }
       
        public IActionResult save(Vmauthoers vm)
        {
            //vm.authors.Image.CopyTo(new FileStream("C:\\x111.png", FileMode.Create));
            //vm.Employee.Image.CopyTo(new FileStream("C:\\x111.png", FileMode.Create));
            string name = Guid.NewGuid().ToString() + "." + vm.authors.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.authors.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.authors.ImagePath = "http://localhost/BookStore/staticPath/" + name;
            authorSevice.Insert(vm.authors);
            vm.liationalities = nService.LoadAll();
            vm.liauthors = authorSevice.loadAll();
            return View("Newauthors",vm);
        }
        public IActionResult Delete(int Id)
        {
            Vmauthoers vm = new Vmauthoers();
            vm.liationalities = nService.LoadAll();
            vm.liauthors = authorSevice.loadAll();
            authorSevice.Delete(Id);
            return View("Newauthors",vm);
        }
        //public IActionResult Edit(int Id)
        //{

        //    Vmauthoers vm = new Vmauthoers();
            
        //    vm.authors = authorSevice.Edit(Id);
        //    vm.liationalities = nService.LoadAll();
        //    vm.liauthors = authorSevice.loadAll();
           

        //    return View("Newauthors", vm);
        //}
        public IActionResult Update(Vmauthoers vm)
        {
            
            authorSevice.update(vm.authors);
            vm.liauthors = authorSevice.loadAll();
            vm.liationalities = nService.LoadAll();
            return View("Newauthors", vm);
        }
        public IActionResult EditAjax(int Id)
        {
            Authors Au = new Authors();

           
            Au = authorSevice.Edit(Id);
            return Json(Au);
        }
    }
}
