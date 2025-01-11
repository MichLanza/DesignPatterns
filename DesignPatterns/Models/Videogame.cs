using System;
using System.Collections.Generic;

namespace DesignPatterns.Models;

public partial class Videogame
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Genero { get; set; } = null!;
}
