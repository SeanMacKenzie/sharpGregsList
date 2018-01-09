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
    public class AnimalsController : Controller
    {
        private readonly AnimalRepository db;
        public AnimalsController(AnimalRepository animalRepo)
        {
            db = animalRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return db.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Animal Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Animal Post([FromBody]Animal animal)
        {
            return db.Add(animal);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Animal Put(int id, [FromBody]Animal animal)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, animal);
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