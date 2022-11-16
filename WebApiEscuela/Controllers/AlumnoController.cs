using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }

        public AlumnoController(DBEscuelaAPIContext context)
        {
            this.Context = context;
        }

        [HttpGet]

        public List<Alumno> Get()//metodo que trae todos los profesores
        {
            //EF
            List<Alumno> alumnos = Context.Alumnos.ToList();
            return alumnos;
        }

        [HttpGet("{id}")]

        public Alumno Get(int id) //trae un profesor
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);
            return alumno;
        }

        [HttpPost]

        public ActionResult Post(Alumno alumno) //INSERTAR
        {
            //EF--agrega en memoria
            Context.Alumnos.Add(alumno);
            //EF---Guarda en la base
            Context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Alumno alumno) //MODIFICAR
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la base

            Context.Entry(alumno).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult<Alumno> Delete(int id) //ELIMINAR
        {
            //EF
            Alumno alumno = Context.Alumnos.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            //EF
            Context.Alumnos.Remove(alumno);
            Context.SaveChanges();

            return alumno;
        }

    }
}
