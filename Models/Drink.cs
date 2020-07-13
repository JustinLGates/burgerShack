using System.ComponentModel.DataAnnotations;

namespace summer2020_BurgerShack.Models
{
  public class Drink
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Range(.01, double.MaxValue)]
    public double Price { get; set; }

    public Drink()
    {

    }

    // Note only used for FakeDb
    public Drink(string name, double price)
    {
      Name = name;
      Price = price;
    }
  }
}
