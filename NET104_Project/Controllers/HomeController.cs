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
        public CuahangDbContext CuahangDbContext;
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
            List<Sanpham> sanphams = _sanphamRepositories.GetAll().ToList();
            return View(sanphams);
        }
        
    }
}
