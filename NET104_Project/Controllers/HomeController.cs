using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET104_Project.Models;
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
        public HomeController(ILogger<HomeController> logger, CuahangDbContext cuahangDbContext)
        {
            _logger = logger;
            CuahangDbContext = cuahangDbContext;
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
            List<Sanpham> sanphams = new List<Sanpham>()
            {
                new Sanpham{Id = Guid.NewGuid(), Ten = "Bimbim", TrangThai = true },
                new Sanpham{Id = Guid.NewGuid(), Ten = "Redbull", TrangThai = false },
                new Sanpham{Id = Guid.NewGuid(), Ten = "TV", TrangThai = true },
                new Sanpham{Id = Guid.NewGuid(), Ten = "ABC", TrangThai = false },
                new Sanpham{Id = Guid.NewGuid(), Ten = "1234", TrangThai = true }
            };
            return View(sanphams);
        }
        
    }
}
