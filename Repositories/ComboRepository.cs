using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class ComboRepository
  {
    public readonly IDbConnection _db;
    public ComboRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<DbCombo> GetAll()
    {
      string sql = "SELECT * FROM combos;";
      return _db.Query<DbCombo>(sql);
    }

    internal DbCombo GetById(int id)
    {
      string sql = "SELECT * FROM combos WHERE id = @id";
      // Create a new object with property id, and value of that variable from the parameter
      return _db.QueryFirstOrDefault<DbCombo>(sql, new { id });
    }

    internal IEnumerable<DbCombo> GetByBurgerId(int id)
    {
      string sql = "SELECT * FROM combos WHERE burgerId = @id";
      return _db.Query<DbCombo>(sql, new { id });
    }

    internal DbCombo Create(DbCombo newDbCombo)
    {
      string sql = @"
            INSERT INTO combos 
            (name, price, description) 
            VALUES 
            (@Name, @Price, @Description);
            SELECT LAST_INSERT_ID();
            ";
      int id = _db.ExecuteScalar<int>(sql, newDbCombo);
      newDbCombo.Id = id;
      return newDbCombo;
    }

    internal DbCombo Edit(DbCombo original)
    {
      string sql = @"
            UPDATE combos
            SET
                name = @Name,
                price = @Price,
                description = @Description
            WHERE id = @Id;
            SELECT * FROM combos WHERE id = @Id;
            ";
      return _db.QueryFirstOrDefault<DbCombo>(sql, original);
    }

    internal DbCombo Delete(DbCombo burgerToDelete)
    {
      string sql = "DELETE FROM combos WHERE id = @Id";
      _db.Execute(sql, burgerToDelete);
      return burgerToDelete;
    }
  }
}