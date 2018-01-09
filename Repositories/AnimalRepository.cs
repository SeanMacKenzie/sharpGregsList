using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using sharpGregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace sharpGregsList.Repositories
{
    public class AnimalRepository
    {
        private readonly IDbConnection _db;

        public AnimalRepository(IDbConnection db)
        {
            _db = db;
        }



        // Find One Find Many add update delete

        public IEnumerable<Animal> GetAll()
        {
            return _db.Query<Animal>($"SELECT * FROM macanimals");
        }

        public Animal GetById(int id)
        {
            return _db.QueryFirstOrDefault<Animal>($"SELECT * FROM macanimals WHERE id = @id", id);
        }

        public Animal Add(Animal animal)
        {

            int id = _db.ExecuteScalar<int>(@"INSERT INTO macanimals (Title, Type,Descript, Contact, Img, Price) 
                    VALUES (@Title, @Type, @Descript, @Contact, @Img, @Price); SELECT LAST_INSERT_ID()", new
            {
                animal.Title,
                animal.Type,
                animal.Descript,

                animal.Contact,
                animal.Img,
                animal.Price
            });
            animal.Id = id;
            return animal;

        }

        public Animal GetOneByIdAndUpdate(int id, Animal animal)
        {
            return _db.QueryFirstOrDefault<Animal>($@"
                UPDATE macproperties SET  
                    Title = @Title,
                    Type = @Type,
                    Descript = @Descript,
                    
                    Contact = @Contact,
                    Img = @Img,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM macanimals WHERE id = {id};", animal);

        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"DELETE FROM macanimals Where ID = @id", id);
            return success > 0 ? "success" : "failed";

        }

    }
}
