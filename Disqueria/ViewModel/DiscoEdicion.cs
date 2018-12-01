using Disqueria.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.ViewModel
{
    public class DiscoEdicion
    {
        public DiscoVM Edicion { get; set; }
        public int DiscoID { get; set; }
        public List<SelectListItem> Generos { get; set; }
        public List<SelectListItem> Discograficas { get; set; }
        public List<SelectListItem> Artistas { get; set; }

        
    }
}
