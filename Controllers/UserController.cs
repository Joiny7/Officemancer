using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Officemancer.Dtos;
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

        [HttpGet("api/Users/GetUserReservations")]
        public IActionResult GetUserReservations(int userid)
        {
            var resp = _userservice.GetUserReservations(userid);
            return Ok(resp);
        }        
        
        [HttpGet("api/Users/GetUserReservation")]
        public IActionResult GetUserReservation(int userReservationId)
        {
            var resp = _userservice.GetUserReservation(userReservationId);
            return Ok(resp);
        }        
        
        [HttpGet("api/Users/GetLastestWarning")]
        public IActionResult GetLastestWarning(int userid)
        {
            var resp = _userservice.GetLastestWarning(userid);
            return Ok(resp);
        }        
        
        [HttpGet("api/Users/GetUser")]
        public IActionResult GetUser(string UserName)
        {
            var resp = _userservice.GetUser(UserName);
            return Ok(resp);
        }        
        
        [HttpGet("api/Users/GetColleagues")]
        public IActionResult GetColleagues(int UserId)
        {
            var resp = _userservice.GetUsers(UserId);
            return Ok(resp);
        }


        [HttpPost("api/User/Login")]
        public IActionResult Login(string username, string password)
        {
            int? id = _userservice.Login(username, password);

            if (id != null)
                return Ok("Success");
            else
                return BadRequest();
        }

        [HttpPost("api/User/BookReservation")]
        public IActionResult BookReservation(Reservation res)
        {
            if (res == null)
                return BadRequest();

            string s = _userservice.CreateReservation(res);
            return Ok(s);
        }

        [HttpPost("api/User/GetMonth")]
        public IActionResult GetMonth(int officeID, int month, int? year)
        {
            return Ok(_userservice.GetMonth(officeID, month, year));
        }

        [HttpPost("api/User/GetOffice")]
        public IActionResult GetOffice(int officeID)
        {
            return Ok(_userservice.GetOffice(officeID));
        }
        // <3
        [HttpPost]
        public IActionResult EditReservation(int reservationId, ReservationDto dto)
        {
            if (dto == null)
                return BadRequest();

            string response = _userservice.UpdateReservation(reservationId, dto);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult DeleteReservation(int reservationId)
        {
            if (reservationId != 0)
                return BadRequest();

            string response = _userservice.DeleteReservation(reservationId);
            return Ok(response);
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