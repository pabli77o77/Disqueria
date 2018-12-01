using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.ViewModel
{
    public class DiscoVM
    {
        [Key]
        public int DiscoID { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "El título del disco es obligatorio")]
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public int ArtistaID { get; set; }
        public string Genero { get; set; }
        public int GeneroID { get; set; }
        public string Discografica { get; set; }
        public int DiscograficaID { get; set; }
    }
}
