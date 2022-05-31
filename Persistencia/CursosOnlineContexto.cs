using Microsoft.EntityFrameworkCore;
using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistencia
{
    public class CursosOnlineContexto : IdentityDbContext<Usuario>
    {
        public CursosOnlineContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity<CursoInstructor>().HasKey(ci=>new{ci.CursoId,ci.InstructorId});
        }

        public DbSet<Comentario> Comentario {get;set;}
        public DbSet<Curso> Curso {get;set;}
        public DbSet<Instructor> Instructor {get;set;}
        public DbSet<Precio> Precio {get;set;}
        public DbSet<CursoInstructor> CursoInstructor {get;set;}
    }
}