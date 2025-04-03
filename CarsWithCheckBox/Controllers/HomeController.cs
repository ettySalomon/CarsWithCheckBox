using CarsWithCheckBox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarsWithCheckBox.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Cars;Integrated Security=true;TrustServerCertificate=yes;";


        public IActionResult Index(string sort)
        {
            var db = new CarsDb(_connectionString);
            var vm = new IndexViewModel
            {
                cars = db.GetAllCars()
            };
            return View(vm);

        }

        public IActionResult NewCar()
        {
            return View();

        }

        [HttpPost]
        public IActionResult SaveNewCar(Car car)
        {
            var db = new CarsDb(_connectionString);
            db.AddCar(car);
            return Redirect("/home/index");

        }

    }
}
