﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Teniaco_SecondSenario_Web.Models;
using Teniaco_SecondSenario_Web.Models.ViewModels.Person;
using Teniaco_SecondSenario_Web.WebServices.Person.Interfaces;

namespace Teniaco_SecondSenario_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService; 
        }
        public async Task<IActionResult> Index()
        {
            var person = new CreatePersonViewModel
            {
                BirthDay = "2023/12/12",
                LastName = "Abbas",
                Mobile = "09032387021",
                Name = "Ariyan",
            };

            var res = await _personService.CreatePerson(person);
            return View();
        }

        public async Task<IActionResult> GetPerson()
        {
            var exampleData = 1;
            var res = await _personService.GetPerson(exampleData);
            return View();
        }

        public async Task<IActionResult> CreatePerson()
        {
            var person = new CreatePersonViewModel
            {
                BirthDay = "2023/12/12",
                LastName = "Abbas",
                Mobile = "09032387021",
                Name = "Ariyan",
            };

            var res = await _personService.CreatePerson(person);
            return View();
        }

        public async Task<IActionResult> GetAllPersons()
        {
            var res = await _personService.GetPersons();
            return View();
        }
    }
}