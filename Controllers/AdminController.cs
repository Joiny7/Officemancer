using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Platypus.Dtos;
using Platypus.Models;
using Platypus.Services;

namespace Platypus.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService _adminservice;

        public AdminController(IAdminService adminservice)
        {
            _adminservice = adminservice;
        }

        [HttpPost("api/Admin/CreateUser")]
        public IActionResult CreateUser(int AdminID, UserDto dto)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.CreateUser(dto);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/CreateWarning")]
        public IActionResult CreateWarning(int AdminID, int CompanyID, string Message)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.CreateWarning(CompanyID, Message, null);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpGet("api/Admin/GetUsers")]
        public IActionResult GetUsers(int AdminID, int companyid)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.GetUsers(companyid);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/SetBannerMessage")]
        public IActionResult SetBannerMessage(int AdminID, string message)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.SetBannerMessage(AdminID, message);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/AddOffice")]
        public IActionResult AddOffice(int AdminID, string OfficeName, int CompanyID, int TotalCapacity, string BannerMessage)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.AddOffice(OfficeName, CompanyID, TotalCapacity, BannerMessage);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/UpdateOffice")]
        public IActionResult UpdateOffice(int AdminID, int OfficeId, string OfficeName, int TotalCapacity, string BannerMessage)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.UpdateOffice(OfficeId, OfficeName, TotalCapacity, BannerMessage);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/UpdateFloor")]
        public IActionResult UpdateFloor(int AdminID, int floorid, string newName, int newMax, bool newBookable)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.UpdateFloor(floorid, newName, newMax, newBookable);
                return Ok(resp);
            }
            else return
                   BadRequest();
        }

        [HttpPost("api/Admin/AddFloor")]
        public IActionResult AddFloor(int AdminID, string name, int officeId, int max, bool bookable)
        {
            if (_adminservice.AdminCheck(AdminID))
            {
                var resp = _adminservice.AddFloor(name,officeId, max, bookable);
                return Ok(resp);
            }
            else return
                   BadRequest();
        }






        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}