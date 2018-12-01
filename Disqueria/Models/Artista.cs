using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disqueria.Models
{
    // Dejo todo dentro del mismo esquema 
    [Table("Artistas")]
    public class Artista
    {
        [Key]
        public int ArtistaID { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "El nombre del artista es obligatorio.")]
        [Column("Artista")]
        [Display(Name = "Artista")]
        public string Nombre { get; set; }
  
    }
}