using Microsoft.EntityFrameworkCore;
using WebApiEscuela.Models;

namespace WebApiEscuela.Data
{
    public class DBEscuelaAPIContext : DbContext
    {
        //EN CORE SIEMPRE SE DECLARA EL CONSTRUCTOR DE ESTA MANERA
        public DBEscuelaAPIContext(DbContextOptions<DBEscuelaAPIContext> options) : base(options) { }

        //DBSET
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
    }
}
