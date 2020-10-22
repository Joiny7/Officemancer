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
    public class UserController : Controller
    {
        private IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        public IActionResult Login(string username, string password)
        {
            bool resp = _userservice.Login(username, password);

            if (resp)
                return Ok();
            else
                return BadRequest();
        }

        public IActionResult BookReservation(Reservation res)
        {
            if (res == null)
                return BadRequest();

            string s = _userservice.CreateReservation(res);
            return Ok(s);
        }

        public IActionResult GetMonth(int officeID, int month, int? year)
        {
            return Ok(_userservice.GetMonth(officeID, month, year));
        }

        public IActionResult GetOffice(int officeID)
        {
            return Ok(_userservice.GetOffice(officeID));
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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