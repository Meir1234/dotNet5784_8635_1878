using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Engineer
{


    public int Id { get; init; }
    public string Email { get; set; }
    public double? Cost { get; set; }
    public string Name { get; set; }
    public Level level { get; set; }


    public Engineer(int id, string? email, string? name, Level level, double? cost)
    {
        Id = id;
        Email = email;
        Name = name;
        level = level;
        Cost = cost;

    }

    public override string ToString()
    {
        return $"Id: {Id}, Email: {Email}, Cost: {Cost?.ToString() ?? "null"}, Name: {Name}, Level: {level}";
    }

}


