using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using RentalCarApp.Models;

namespace RentalCarApp.API.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return new List<Car> {
                new Car {Id=1, Brand="Toyota", Model="Yaris", PlateNumber="ABC123"},
                new Car {Id=2, Brand="Nissan", Model="Trail X", PlateNumber="DEF456"},
                new Car {Id=3, Brand="Honda", Model="Jazz", PlateNumber="GIO789"}
            };
        }
    }
}
