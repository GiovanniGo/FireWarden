using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using RentalCarApp.Models;
using System.Linq;

namespace RentalCarApp.API.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {

        private readonly CarsAppContext dbContext;
        public CarsController(CarsAppContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return dbContext.Cars;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var car = dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            { return new HttpNotFoundResult(); }
            else
            { return new ObjectResult(car); }
        }
        [HttpPost]
        public IActionResult Post([FromBody]Car car)
        {

            if (car.Id == 0)
            {
                dbContext.Cars.Add(car);
                dbContext.SaveChanges();
                return new ObjectResult(car);
            }
            else
            {
            //var original = dbContext.Cars.FirstOrDefault(m => m.Id == car.Id);
            //original.Title = car.Title;
            //original.Director = car.Director;
            //dbContext.SaveChanges();
            //return new ObjectResult(original);
            return new ObjectResult(car);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var car = dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                dbContext.Cars.Remove(car);
                dbContext.SaveChanges();
            }
            return new HttpStatusCodeResult(200);
        }
    }
}
