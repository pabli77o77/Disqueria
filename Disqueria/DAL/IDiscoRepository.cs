using Disqueria.Models;
using Disqueria.ViewModel;
using System.Collections.Generic;

namespace Disqueria.DAL
{
    public interface IDiscoRepository : IGenericRepository<Disco>
    {
        List<DiscoVM> Grilla();
        DiscoEdicion Get_Edicion(int? id);
        bool Add(DiscoVM vm);
        bool Update(DiscoVM vm);
        PagedList<DiscoVM> PagedGrid(int size = 10, int page = 1, string filter = null, string sort = "Nombre", string sordir = "ASC");
    }
}