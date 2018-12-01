using Disqueria.Models;
using Disqueria.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Disqueria.DAL
{
    public class DiscoRepository : GenericRepository<Disco>, IDiscoRepository
    {
        public DiscoRepository(ApplicationDbContext context):base(context) {
        }

        public DiscoEdicion Get_Edicion(int? id)
        {
            DiscoEdicion de = new DiscoEdicion();
            de.Edicion = DiscoContext.Discos.Where(c => c.DiscoID == id)
                .Select(s => new DiscoVM
                {
                    DiscoID = s.DiscoID,
                    Titulo = s.Titulo,
                    ArtistaID = s.ArtistaID,
                    Artista = s.Artista.Nombre,
                    Genero = s.Genero.Nombre,
                    GeneroID = s.GeneroID,
                    Discografica = s.Discografica.Nombre,
                    DiscograficaID = s.DiscograficaID
                }).FirstOrDefault();
            de.Generos = DiscoContext.Generos.Select(s => new SelectListItem { Value = s.GeneroID.ToString(), Text = s.Nombre }).ToList();
            de.Discograficas = DiscoContext.Discograficas.Select(s => new SelectListItem { Value = s.DiscograficaID.ToString(), Text = s.Nombre }).ToList();
            de.Artistas = DiscoContext.Artistas.Select(s => new SelectListItem { Value=s.ArtistaID.ToString(), Text=s.Nombre}).ToList();

            return de;
        }

        public List<DiscoVM> Grilla()
        {
            return DiscoContext.Discos.Select(s =>
            new DiscoVM
            {
                Artista = s.Artista.Nombre,
                ArtistaID = s.ArtistaID,
                Genero = s.Genero.Nombre,
                GeneroID = s.GeneroID,
                Discografica = s.Discografica.Nombre,
                DiscograficaID=s.DiscograficaID,
                Titulo = s.Titulo,
                DiscoID = s.DiscoID
            }).ToList();
        }

        public bool Add(DiscoVM vm)
        {
            return this.Add(new Disco
            {
                DiscoID = vm.DiscoID,
                DiscograficaID = vm.DiscograficaID,
                GeneroID = vm.GeneroID,
                ArtistaID = vm.ArtistaID,
                Titulo = vm.Titulo
                
            });
        }

        public bool Update(DiscoVM vm)
        {
            return this.Update(new Disco
            {
                DiscoID = vm.DiscoID,
                DiscograficaID = vm.DiscograficaID,
                GeneroID = vm.GeneroID,
                ArtistaID = vm.ArtistaID,
                Titulo = vm.Titulo

            });
        }

        public PagedList<DiscoVM> PagedGrid(int size = 10, int page = 1, string filter = "", string sort = "Nombre", string sordir = "ASC")
        {
            var records = new PagedList<DiscoVM>();
            records.Content = DiscoContext.Discos
                .Where(x => (filter == null)
                || (x.Genero.Nombre.Contains(filter))
                || (x.Titulo.Contains(filter))
                ).Select(s =>
                new DiscoVM
                {
                    Artista = s.Artista.Nombre,
                    ArtistaID = s.ArtistaID,
                    Genero = s.Genero.Nombre,
                    GeneroID = s.GeneroID,
                    Discografica = s.Discografica.Nombre,
                    DiscograficaID = s.DiscograficaID,
                    Titulo = s.Titulo,
                    DiscoID = s.DiscoID
                }).Skip(page - 1)
                .Take(size).ToList();
            records.TotalRecords = DiscoContext.Discos
                .Where(x => (filter == null)
                || (x.Genero.Nombre.Contains(filter)
                || (x.Titulo.Contains(filter)))
                ).Count();
            return records;
        }

        public ApplicationDbContext DiscoContext
        {
            get { return context as ApplicationDbContext; }
        }

        //public void Dispose()
        //{
        //    context.Dispose();
        //}
    }
}
