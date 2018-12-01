using Disqueria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disqueria.DAL
{
    public class DiscograficaRepository : GenericRepository<Discografica>, IDiscograficaRepository, IDisposable
    {
        public DiscograficaRepository(ApplicationDbContext context) : base(context)
        {

        }
        public ApplicationDbContext DiscograficaContext
        {
            get { return context as ApplicationDbContext; }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
