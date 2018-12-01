using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.Models
{
    [Table("Discos")]
    public class Disco
    {
        [Key]
        [Display(Name = "ID")]
        public int DiscoID { get; set; }
        [MaxLength(100)]
        [Required (ErrorMessage ="El título del disco es obligatorio")]
        [Column("Disco")]
        [Display(Name = "Disco")]
        public string Titulo { get; set; }
        public Artista Artista { get; set; }
        public int ArtistaID { get; set; }
        public Genero Genero { get; set; }
        public int GeneroID { get; set; }
        public Discografica Discografica { get; set; }
        public int DiscograficaID { get; set; }
        public Disco() { }
    }
}
