using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Officemancer.Models;
using Officemancer.Services;

namespace Officemancer.Controllers
{
    public class AdminController : Controller
    {
        private IAdminService _adminservice;

        public AdminController(IAdminService adminservice)
        {
            _adminservice = adminservice;
        }

        [HttpPost("api/Admin/SetBannerMessage")]
        public IActionResult SetBannerMessage(int userid, string message)
        {
            if (_adminservice.AdminCheck(userid))
            {
                var resp = _adminservice.SetBannerMessage(userid, message);
                return Ok(resp);
            }
            else return
                    BadRequest();
        }

        [HttpPost("api/Admin/UpdateFloor")]
        public IActionResult UpdateFloor(int userid, Floor f)
        {
            if (_adminservice.AdminCheck(userid))
            {
                var resp = _adminservice.UpdateFloor(f);
                return Ok(resp);
            }
            else return
                   BadRequest();
        }

        [HttpPost("api/Admin/AddFloor")]
        public IActionResult AddFloor(int userid, Floor f)
        {
            if (_adminservice.AdminCheck(userid))
            {
                var resp = _adminservice.AddFloor(f);
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