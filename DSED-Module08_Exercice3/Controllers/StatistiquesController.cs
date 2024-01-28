﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSED_Module08_Exercice3.Controllers
{
    [Route("api/Statistiques")]
    [ApiController]
    public class StatistiquesController : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Appel>> Get()
        {
            return Ok(Statistique.GetAppels());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Appel> Get(int id)
        {
            var appel = Statistique.GetByIdAppel(id);
            if (appel != null) return Ok(appel);

            return NotFound();

        }

        [HttpPost("{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]

        public ActionResult Post(int id, [FromBody] Appel p_Appel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            p_Appel.Id = Statistique.DernierId + 1;
            p_Appel.DebutAppel = DateTime.Now;
            p_Appel.IdAgent = id;

            Statistique.AddAppel(p_Appel);
            return CreatedAtAction(nameof(Get), new { id = p_Appel.Id }, p_Appel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id)
        {

            int index = Statistique.GetAppels().FindIndex(a => a.Id == id);

            if (index < 0) 
            {
                return NotFound();
            }

            Statistique.GetByIdAppel(id).FinAppel = DateTime.Now;

            return NoContent();

        }
    }
}