using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using sharpGregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace sharpGregsList.Repositories
{
    public class AutoRepository
    {
        private readonly IDbConnection _db;

        public AutoRepository(IDbConnection db)
        {
            _db = db;
        }



        // Find One Find Many add update delete

        public IEnumerable<Auto> GetAll()
        {
            return _db.Query<Auto>($"SELECT * FROM macautos");
        }

        public Auto GetById(int id)
        {
            return _db.QueryFirstOrDefault<Auto>($"SELECT * FROM macautos WHERE id = @id", id);
        }

        public Auto Add(Auto auto)
        {

            int id = _db.ExecuteScalar<int>(@"INSERT INTO macautos (Title, Make, Model, Descript, Contact, Img, Price)
                VALUES (@Title, @Make, @Model, @Descript, @Contact, @Img, @Price); SELECT LAST_INSERT_ID()", new
            {
                auto.Title,
                auto.Make,
                auto.Model,
                auto.Descript,
                auto.Contact,
                auto.Img,
                auto.Price
            });
            auto.Id = id;
            return auto;

        }

        public Auto GetOneByIdAndUpdate(int id, Auto auto)
        {
            return _db.QueryFirstOrDefault<Auto>($@"
                UPDATE macautos SET  
                    Title = @Title,
                    Make = @Make,
                    Model = @Model,
                    Descript = @Descript,
                    Contact = @Contact,
                    Img = @Img,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM macautos WHERE id = {id};", auto);

        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"DELETE FROM macautos Where ID = @id", id);
            return success > 0 ? "success" : "failed";

        }

    }
}
