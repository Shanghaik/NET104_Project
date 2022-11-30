using Microsoft.AspNetCore.Http;
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
            var thongtin = HttpContext.Session.GetString("username");
            if (thongtin != null)
            {
                ViewData["thongtin"] = thongtin;
                return View(); // truyền dữ liệu lấy được từ Session
            }
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
            // ViewData
            List<int> so = new List<int>() { 1, 2, 3, 4 };
            string s = "Xin chào các bạn, mình có số: ";
            ViewData["so"] = so;
            ViewData["chu"] = s;
            List<Guid> ids = new List<Guid>();
            foreach (var item in _sanphamRepositories.GetAll())
            {
                ids.Add(item.Id);
            }
            ViewData["allId"] = ids;
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
            return View(_sanphamRepositories.GetById(id));
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

        public IActionResult SearchByName()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SearchByName(string xxx)
        {
            if (!string.IsNullOrEmpty(xxx))
            {
                var result = _sanphamRepositories.GetAll().Where(p => p.Ten.Contains(xxx)).ToList();
                if (result.Count > 0)
                {
                    ViewData["amount"] = "Số lượng sản phẩm tìm kiếm được là: " + result.Count;
                    return View(result);
                }
                else
                {
                    ViewData["result"] = "Không có sản phẩm nào mà tên có chứa " + xxx;
                }
            }          
            return View();
        }

        [HttpGet]
        public IActionResult SearchByName2(string xxx)
        {
            if (!string.IsNullOrEmpty(xxx))
            {
                var result = _sanphamRepositories.GetAll().Where(p => p.Ten.Contains(xxx)).ToList();
                if (result.Count > 0)
                {
                    ViewData["amount"] = "Số lượng sản phẩm tìm kiếm được là: " + result.Count;
                    return View("HienthiSanpham", result); // Dùng chung view thì ta return đúng về tên view dùng chung
                }
                else
                {
                    ViewData["result"] = "Không có sản phẩm nào mà tên có chứa " + xxx;
                }
            }
            return View("HienthiSanpham");
        }

        public IActionResult Login(string username, string password)
        {
            if(string.IsNullOrEmpty(username) || password.Length < 6)
            {
                ViewData["ketqua"] = "Sai thông tin tài khoản";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("username", username); // Lưu dữ liệu vào Session
                return RedirectToAction("Index"); // Đặng nhập thành công thì đẩy sang trang chủ
            }
            return View();
        }



    }
}
