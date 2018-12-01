using Disqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.DAL
{
    public class ArtistaRepository : GenericRepository<Artista>, IArtsitaRepository, IDisposable
    {
        public ArtistaRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ArtistaContext
        {
            get { return context as ApplicationDbContext; }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
