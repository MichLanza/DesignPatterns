using System.ComponentModel.DataAnnotations;

namespace DesignPatterns.MVC.Models.ViewModels
{
    public class AddVideoGameViewModel
    {

        [Required]
        [Display(Name = "Nombre del videojuego")]
        public string Nombre { get; set; } = null!;

        [Required]
        [Display(Name = "Género del videojuego")]
        public string Genero { get; set; } = null!;

        [Display(Name = "Compañía")]
        public Guid? CompanyId { get; set; }

        [Display(Name = "Compañía del videojuego")]
        public string? CompanyName { get; set; } = null!;
    }
}
