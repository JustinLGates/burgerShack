using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;


namespace BurgerShack.Services
{
  public class FryService
  {
    private readonly FryRepository _repo;
    public FryService(FryRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Fry> Get()
    {
      return _repo.GetAll();
    }

    internal Fry Get(int id)
    {
      Fry found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Fry Id");
      }
      return found;
    }

    internal Fry Create(Fry newFry)
    {
      _repo.Create(newFry);
      return newFry;
    }

    internal Fry Edit(Fry editFry)
    {
      Fry original = Get(editFry.Id);
      original.Name = editFry.Name.Length > 0 ? editFry.Name : original.Name;
      original.Price = editFry.Price > 0 ? editFry.Price : original.Price;
      original.Size = editFry.Size.Length > 0 ? editFry.Size : original.Size;
      _repo.Edit(original);
      return original;

    }

    internal Fry Delete(int id)
    {
      Fry fryToDelete = Get(id);
      _repo.Delete(fryToDelete);
      return fryToDelete;
    }
  }
}
