using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            _logger.LogInformation("Loglama yapıldı");

            var client = new MongoClient("mongodb+srv://AcizKul:AcizKul112345@cluster0.r2h1i.mongodb.net/CarParkDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("CarParkDb");

            var collection = database.GetCollection<Test>("Test");

            var test = new Test()
            {
                _Id = ObjectId.GenerateNewId(),
                NameSurname = "AHMET Denemeler23",
                Age = 45,
                AddressList = new List<Address>()
                {
                     new Address
                     {
                         Title="Ev Adres",
                         Description="İzmir"
                     },
                      new Address
                      {
                        Title="İş Adres",
                        Description="Germany"
                      }

                }
            };

            collection.InsertOne(test);

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
    }
}
