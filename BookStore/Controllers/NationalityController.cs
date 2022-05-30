using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class NationalityController : Controller
    {
        INationalityService nService;
        public NationalityController(INationalityService _nService) {
            nService = _nService;
        }
        public IActionResult Index()
        {
            VmNationlity Vm = new VmNationlity();
           Vm.linationalities= nService.LoadAll();
            return View("NewNatioality",Vm);
        }
        public IActionResult save(VmNationlity vm)
        {
            nService.Insert(vm.nationality);
            vm.linationalities = nService.LoadAll();
            return View("NewNatioality",vm);
        }
        
    }
}
