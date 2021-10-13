using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Baraja_PilarMontenegro.Models
{
   
    public class Naipe
    {
        [Key]

        [Required]
        //[Range(typeof(char), "A", "K")]

        [StringLength(1, MinimumLength = 1, ErrorMessage = "Por favor Ingrese una letra de la A hasta la K")]
        public string NaipeId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Por favor Ingrese entre 5 a 50 caracteres")]
        [Display(Name = "Nombre de la carta")]
        public string Nombre { get; set; }

        [Required]
        [Url]
       // [StringLength(100, MinimumLength = 5, ErrorMessage = "Por favor Ingrese entre 5 a 100 caracteres")]
        public string Imagen { get; set; }
    }
}
