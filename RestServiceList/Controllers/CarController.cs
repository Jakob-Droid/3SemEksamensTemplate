using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServiceList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private static List<Car> CarList = new List<Car>
        {
            new Car(){Id = 1},
            new Car(){Id = 2},
            new Car(){Id = 3},
            new Car(){Id = 4},
            new Car(){Id = 5},
            new Car(){Id = 6},
            new Car(){Id = 7},
            new Car(){Id = 8}
        };

        
        // GET: api/<CarController>
        [HttpGet]
        public List<Car> Get()
        {
            return CarList;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return CarList.Find(x=> x.Id == id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            CarList.Add(value);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            Car item = Get(id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Color = value.Color;
                item.Name = value.Name;
                item.RegNo = value.RegNo;
            }
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CarList.RemoveAll(x => x.Id == id);
        }
    }
}
