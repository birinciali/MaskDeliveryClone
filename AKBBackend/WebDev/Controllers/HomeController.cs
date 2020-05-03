using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDev.Models;

namespace WebDev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IApplicantService _applicantManager;
        public HomeController(ILogger<HomeController> logger, IApplicantService applicantManager)
        {
            _applicantManager = applicantManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //https://localhost:44386/home/applyforperson

        [HttpGet]
        public IActionResult ApplyForPerson()
        {
            return View(new PersonViewModel());
        }

        [HttpPost]
        public string ApplyForPerson(PersonViewModel personViewModel)
        {
            Person person = new Person();
            person.Name = personViewModel.Name;
            person.Surname = personViewModel.Surname;
            person.BirthYear = personViewModel.BirthYear;

            if (personViewModel.PassportNo==null)
            {
                person.Number = personViewModel.TcNumber;
            }

            else
            {
                person.Number = personViewModel.PassportNo;
            }

            if (_applicantManager.ApplyForMask(person))
            {
                return "Alabilirsiniz";
            }

            else
                return "Üzgünüz, girdiginiz bilgilerle maske alamazsınız.";
        }
    }
}
