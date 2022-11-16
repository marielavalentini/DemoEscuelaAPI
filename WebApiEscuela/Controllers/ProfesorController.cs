using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiEscuela.Data;
using WebApiEscuela.Models;

namespace WebApiEscuela.Controllers
{
    // GET /api/Profesor

    [Route("api/[controller]")]
    [ApiController]

    public class ProfesorController : ControllerBase
    {
        public DBEscuelaAPIContext Context { get; set; }

        public ProfesorController(DBEscuelaAPIContext context) 
        {
            this.Context = context;        
        }

        [HttpGet]

        public List<Profesor>Get()//metodo que trae todos los profesores
        {
            //EF
            List<Profesor> profesores = Context.Profesores.ToList();
            return profesores;
        }

        [HttpGet("{id}")]

        public Profesor Get(int id) //trae un profesor
        {
            //EF
            Profesor profesor = Context.Profesores.Find(id);
            return profesor;
        }

        [HttpPost]

        public ActionResult Post(Profesor profesor) //INSERTAR
        {
            //EF--agrega en memoria
            Context.Profesores.Add(profesor);
            //EF---Guarda en la base
            Context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]

        public ActionResult Put (int id,[FromBody] Profesor profesor) //MODIFICAR
        {
            if(id != profesor.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la base

            Context.Entry(profesor).State = EntityState.Modified;
            Context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult<Profesor> Delete(int id) //ELIMINAR
        {
            //EF
            Profesor profesor = Context.Profesores.Find(id);
            if(profesor == null)
            {
                return NotFound();
            }
            //EF
            Context.Profesores.Remove(profesor);
            Context.SaveChanges();

            return profesor;
        }
    }
}
