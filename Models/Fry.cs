using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Fry
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Range(.01, double.MaxValue)]
    public double Price { get; set; }
    public string Size { get; set; }

    public Fry()
    {

    }

    // Note only used for FakeDb
    public Fry(string name, double price, string size)
    {
      Name = name;
      Price = price;
      Size = size;
    }
  }
}