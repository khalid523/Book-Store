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
    public class BooksController : Controller
    {
        IBookService bService;
        ICategoryservice cservice;
        IAuthorSevice aservice;
        public BooksController(IBookService _BService,ICategoryservice _cservice ,IAuthorSevice _aservice)
        {
            bService = _BService;
            cservice = _cservice;
            aservice = _aservice;
        }
        public IActionResult Index()
        {
            ViewData["isEdited"] = false;
            vmBook vm = new vmBook();
            vm.liauthors = aservice.loadAll();
            vm.licateogrry = cservice.LoadAll();
            vm.libooks = bService.loadAll();
            return View("NewBook",vm);
        }
        public IActionResult save(vmBook vm)
        {
            ViewData["isEdited"] = false;
            string name = Guid.NewGuid().ToString() + "." + vm.Books.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.Books.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.Books.ImagePath = "http://localhost/BookStore/staticPath/" + name;
            bService.Insert(vm.Books);
            vm.licateogrry = cservice.LoadAll();
            vm.liauthors = aservice.loadAll();
            vm.libooks = bService.loadAll();
            return View("NewBook",vm);
        }
        public IActionResult Delete(int Id)
        {
            vmBook vm = new vmBook();
            vm.liauthors = aservice.loadAll();
            vm.libooks = bService.loadAll();
            vm.licateogrry = cservice.LoadAll();
            bService.Delete(Id);
            return View("NewBook",vm);
        }
        //public IActionResult Edit(int Id)
        //{
        //    ViewData["isEdited"] = true;
        //    vmBook vm = new vmBook();
        //    vm.Books = bService.Edit(Id);
        //    vm.libooks = bService.loadAll();
        //    vm.licateogrry = cservice.LoadAll();
        //    vm.liauthors = aservice.loadAll();
        //    return View("NewBook", vm);
        //}
        public IActionResult Update(vmBook vm)
        {

            ViewData["isEdited"] = true;
            bService.Update(vm.Books);
            vm.libooks = bService.loadAll();
            vm.liauthors = aservice.loadAll();
            vm.licateogrry = cservice.LoadAll();
            return View("NewBook",vm);
        }
        public IActionResult EditAjax(int Id)
        {
            Books B = new Books();

            B = bService.Edit(Id);
            return Json(B);
        }
    }
}
