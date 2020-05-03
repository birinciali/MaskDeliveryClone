using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ApplyController : Controller
    {

        //private IApplicantService _applicantService;
        //public ApplyController(IApplicantService applicantService)
        //{
        //    _applicantService = applicantService;
        //}

        [HttpGet]
        public IActionResult ApplyForPerson()
        {
            return View(new PersonViewModel());
        }

        [HttpPost]
        public string ApplyForPerson(PersonViewModel personViewModel)
        {
            return "OK";
        }
    }
}