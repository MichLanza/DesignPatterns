using System;
using System.Collections.Generic;

namespace DesignPatterns.Models.Entities;

public partial class Company
{
    public string? Name { get; set; }

    public Guid Uid { get; set; }

    public virtual ICollection<Videogame> Videogames { get; set; } = new List<Videogame>();
}
