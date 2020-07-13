using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class FryRepository
  {
    public readonly IDbConnection _db;
    public FryRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Fry> GetAll()
    {
      string sql = "SELECT * FROM fries;";
      return _db.Query<Fry>(sql);
    }

    internal Fry GetById(int id)
    {
      string sql = "SELECT * FROM fries WHERE id = @id";
      // Create a new object with property id, and value of that variable from the parameter
      return _db.QueryFirstOrDefault<Fry>(sql, new { id });
    }

    internal Fry Create(Fry newFry)
    {
      string sql = @"
            INSERT INTO fries 
            (name, price, description) 
            VALUES 
            (@Name, @Price, @Description);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, newFry);
      newFry.Id = id;
      return newFry;
    }

    internal Fry Edit(Fry original)
    {
      string sql = @"
            UPDATE fries
            SET
                name = @Name,
                price = @Price,
                description = @Description
            WHERE id = @Id;
            SELECT * FROM fries WHERE id = @Id;
            ";
      return _db.QueryFirstOrDefault<Fry>(sql, original);
    }

    internal Fry Delete(Fry fryToDelete)
    {
      string sql = "DELETE FROM fries WHERE id = @Id";
      _db.Execute(sql, fryToDelete);
      return fryToDelete;
    }
  }
}