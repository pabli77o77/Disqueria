using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disqueria.Models
{
    [Table("Discograficas")]
    public class Discografica
    {
        [Key]
        public int DiscograficaID { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "El nombre de la discográfica es obligatorio.")]
        [Column("Discografica")]
        [Display(Name = "Discográfica")]
        public string Nombre { get; set; }
    }
}