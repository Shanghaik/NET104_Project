using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET104_Project.IRepositories;
using NET104_Project.Models;
using NET104_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NET104_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //public CuahangDbContext CuahangDbContext;
        public ISanphamRepositories _sanphamRepositories;
        public HomeController(ILogger<HomeController> logger, ISanphamRepositories sanphamRepositories)
        {
            _logger = logger;
            _sanphamRepositories = sanphamRepositories;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TestChucNang()
        {
            return View();
        }

        public IActionResult TestChucNang2()
        {
            return RedirectToAction("HienthiSanpham"); // Điều hướng về action index
        }

        public IActionResult HienthiSanpham()
        {
            var sanphams = _sanphamRepositories.GetAll();
            return View(sanphams);
        }

        public IActionResult Details(Guid id)
        {
            var x = _sanphamRepositories.GetById(id);
            return View(x);
        }

        public IActionResult CreateNew(Sanpham sanpham)
        {
            if (_sanphamRepositories.AddSanpham(sanpham))
            {
                return RedirectToAction("HienthiSanpham");
            }
            else return View();
        }
        public IActionResult Delete(Sanpham sp)
        {
            if (_sanphamRepositories.RemoveSanpham(sp))
            {
                return View();
            }
            else return BadRequest();
        }
        public IActionResult Edit(Guid id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Sanpham sp)
        {
            if (_sanphamRepositories.UpdateSanpham(sp))
            {
                return RedirectToAction("HienthiSanpham");
            }
            else return BadRequest();
        }

    }
}
