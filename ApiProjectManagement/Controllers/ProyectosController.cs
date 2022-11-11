using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Management.Models;
using Project_Management.Repositories;

namespace Project_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosController : ControllerBase
    {
        private readonly IProyectosRepository _proyectosRepository;

         public ProyectosController(IProyectosRepository proyectosRepository)
        {
            _proyectosRepository = proyectosRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Proyectos>> GetProyectos()
        {
            return await _proyectosRepository.Get();
        }

          [HttpGet("{id}")]
        public async Task<ActionResult<Proyectos>> GetProyectos(int id)
        {
            return await _proyectosRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Proyectos>>PostTools([FromBody] Proyectos proyectos)
        {
            var newProyecto = await _proyectosRepository.Create(proyectos);
            return CreatedAtAction(nameof(GetProyectos), new { id = newProyecto.Id_Proyecto }, newProyecto);
        }

        [HttpPut]
        public async Task<ActionResult> PutTools(int id, [FromBody] Proyectos proyectos)
        {
            if(id != proyectos.Id_Proyecto)
            {
                return BadRequest();
            }

            await _proyectosRepository.Update(proyectos);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var proyectosToDelete = await _proyectosRepository.Get(id);
            if (proyectosToDelete == null)
                return NotFound();

            await _proyectosRepository.Delete(proyectosToDelete.Id_Proyecto);
            return NoContent();
        }

    



    }

    


}