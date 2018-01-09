using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using sharpGregsList.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace sharpGregsList.Repositories
{
    public class PropertyRepository
    {
        private readonly IDbConnection _db;

        public PropertyRepository(IDbConnection db)
        {
            _db = db;
        }

        

        // Find One Find Many add update delete

        public IEnumerable<Property> GetAll()
        {
           return _db.Query<Property>($"SELECT * FROM macproperties");
        }

        public Property GetById(int id)
        {
           return _db.QueryFirstOrDefault<Property>($"SELECT * FROM macproperties WHERE id = @id", id);
        }

        public Property Add(Property property)
        {
               
                int id = _db.ExecuteScalar<int>(@"INSERT INTO macproperties (Title, Type, Descript, Size, Contact, Img, Price)
                 VALUES (@Title, @Type, @Descript, @Size, @Contact, @Img, @Price); SELECT LAST_INSERT_ID()",  new {
                    property.Title,
                    property.Type,
                    property.Descript,
                    property.Size,
                    property.Contact,
                    property.Img,
                    property.Price
                 });
                property.Id = id;
                return property;
            
        }

         public Property GetOneByIdAndUpdate(int id, Property property)
        {
                return _db.QueryFirstOrDefault<Property>($@"
                UPDATE macproperties SET  
                    Title = @Title,
                    Type = @Type,
                    Descript = @Descript,
                    Size = @Size,
                    Contact = @Contact,
                    Img = @Img,
                    Price = @Price
                WHERE Id = {id};
                SELECT * FROM macproperties WHERE id = {id};", property);
            
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute(@"DELETE FROM macproperties Where ID = @id", id);
            return success > 0 ? "success" : "failed";

        }

    }
}
