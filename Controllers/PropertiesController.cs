using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sharpGregsList.Models;
using sharpGregsList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace sharpGregsList.Controllers
{
    [Route("api/[controller]")]
    public class PropertiesController : Controller
    {
        private readonly PropertyRepository db;
        public PropertiesController(PropertyRepository propertyRepo)
        {
            db = propertyRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            return db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Property Post([FromBody]Property property)
        {
            return db.Add(property);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Property Put(int id, [FromBody]Property property)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, property);
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}