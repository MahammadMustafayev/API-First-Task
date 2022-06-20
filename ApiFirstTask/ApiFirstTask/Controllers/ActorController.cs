using ApiFirstTask.DAL;
using ApiFirstTask.DTOs;
using ApiFirstTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFirstTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private AppDbContext _context { get; }
        public ActorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
      
        public IActionResult All()
        {
            return Ok(_context.Actors.Where(a=>a.IsDeleted==false));
        }
        [HttpGet("{id}")]
        
        public IActionResult Get(int id)
        {
            Actor actor = _context.Actors.Where(a=>a.IsDeleted==false && a.Id==id).FirstOrDefault();
            if (actor == null) 
            return StatusCode(StatusCodes.Status404NotFound, new { statusCode=1055,message="Actor couldnt found"});
            return Ok(actor);
        }
        [HttpPost]
        public IActionResult Create(CreateActorDto actordto)
        {
            if (!ModelState.IsValid) return StatusCode(StatusCodes.Status400BadRequest);
            Actor actor = new Actor
            {
                Name = actordto.Name,
                ImageUrl = actordto.InageUrl,
                IsDeleted = false,
                IsName = false,
                CreatedTime = DateTime.Now
            };
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id,Actor actor)
        {
            Actor exstactor = _context.Actors.Find(id);
            if (exstactor is null) return StatusCode(StatusCodes.Status400BadRequest);
            exstactor.Name = actor.Name;
            exstactor.ImageUrl = actor.ImageUrl;
            _context.SaveChanges();
            return Ok(exstactor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Actor actor = _context.Actors.Find(id);
            if (actor is null) return StatusCode(StatusCodes.Status404NotFound);
            _context.Actors.Remove(actor);
            _context.SaveChanges();
                return NoContent();
        }

    }
}
