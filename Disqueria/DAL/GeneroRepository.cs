using Disqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.DAL
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository, IDisposable
    {
        public GeneroRepository(ApplicationDbContext context) : base(context)
        { }

        //public IEnumerable<>

        public ApplicationDbContext GeneroContext
        {
            get { return context as ApplicationDbContext; }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
