using Disqueria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disqueria.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Disqueria.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public class EntidadConfiguration : IEntityTypeConfiguration<Entidad>
        {
            public void Configure(EntityTypeBuilder<Entidad> builder)
            {
                builder.HasKey(o => o.EntidadID);
                builder.ToTable("Entidades");
            }
        }

        public class DiscoConfiguration : IEntityTypeConfiguration<Disco>
        {
            public void Configure(EntityTypeBuilder<Disco> builder)
            {
                builder.HasKey(o => o.DiscoID);
                builder.Property(t => t.DiscoID).IsRequired().HasColumnName("DiscoID");
                builder.Property(t => t.Titulo).IsRequired().HasMaxLength(100);
                builder.ToTable("Discos");

            }
        }

        public class DiscoVMConfiguration : IEntityTypeConfiguration<DiscoVM>
        {
            public void Configure(EntityTypeBuilder<DiscoVM> builder)
            {
                builder.HasKey(x => x.DiscoID);
                builder.Property(x => x.DiscoID).IsRequired().HasColumnName("DiscoID");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DiscoConfiguration());
            builder.Entity<Disco>()
                .HasKey(a => new { a.DiscoID, a.Titulo });

            builder.ApplyConfiguration(new DiscoVMConfiguration());
            builder.Entity<DiscoVM>().HasKey(z => new { z.DiscoID, z.Titulo });

            builder.Entity<Entidad>().Property(b => b.EntidadID)
                .HasColumnName("EntidadID");
            builder.Entity<Entidad>().Property(b => b.TipoEntidad)
                .HasColumnName("TipoEntidad");
            builder.Entity<Disco>().Property(b => b.DiscoID)
                .HasColumnName("DiscoID");
            builder.Entity<Disco>().Property(b => b.Titulo)
                .HasColumnName("Titulo");
            builder.Entity<Genero>().Property(b => b.GeneroID)
                .HasColumnName("GeneroID");
            builder.Entity<Genero>().Property(b => b.Nombre)
                .HasColumnName("Genero");

            builder.Entity<Disco>().ToTable("Discos");
            builder.Entity<Artista>().ToTable("Artistas");
            builder.Entity<Genero>().ToTable("Generos");
            builder.Entity<Discografica>().ToTable("Discograficas");

            // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            // look at this answer: https://stackoverflow.com/a/43075152/3419825
            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Artista> Artistas {get;set;}
        public DbSet<Disco> Discos {get;set;}
        public DbSet<Discografica> Discograficas {get;set;}
        public DbSet<Genero> Generos {get;set;}
        public DbSet<Disqueria.ViewModel.DiscoVM> DiscoVM { get; set; }

    }
}
