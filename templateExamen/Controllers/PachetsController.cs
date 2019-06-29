using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using templateExamen.Services;
using templateExamen.ViewModels;

namespace templateExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PachetsController : ControllerBase
    {
        private IPachetService pachetService;


        public PachetsController (IPachetService pachetService)
        {
            this.pachetService = pachetService;
        }

        /// <summary>
        /// Get all Pachets from DB
        /// </summary>
        /// <returns>A list with all Pachets</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Regular,Moderator,Admin")]
        public IEnumerable<PachetGetModel> GetAll()
        {
            return pachetService.GetAll();
        }







        /// <summary>
        /// Find an Pachet by the given id.
        /// </summary>
        /// <remarks>
        /// Sample response:
        ///
        ///     Get /pachets
        ///     {  
        ///        
        ///        
        ///     }
        /// </remarks>
        /// <param name="id">The id given as parameter</param>
        /// <returns>The pachet with the given id</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
 
        // GET: api/pachets/5
        [HttpGet("{id}", Name = "GetPachet")]
        [Authorize(Roles = "Regular")]
        public IActionResult Get(int id)
        {
            var found = pachetService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        /// <summary>
        /// Add an new Pachet
        /// </summary>
        ///   /// <remarks>
        /// Sample response:
        ///
        ///     Post /pachets
        ///     {
        ///         
        ///     }
        /// </remarks>
        /// <param name="pachetPostModel">The input pachet to be added</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Moderator,Admin")]
        [HttpPost]
        public void Post([FromBody] PachetPostModel pachetPostModel)
        {
            pachetService.Create(pachetPostModel);
        }

        /// <summary>
        /// Modify an Pachet if exists, or add if not exist
        /// </summary>
        /// <param name="id">pachet id to update</param>
        /// <param name="pachetPostModel">object pachetPostModel to update</param>
        /// Sample request:
        ///     <remarks>
        ///     Put /pachets/id
        ///     {
        ///        
        ///      }
        /// </remarks>
        /// <returns>Status 200 daca a fost modificat</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] PachetPostModel pachetPostModel)
        {
            var result = pachetService.Upsert(id, pachetPostModel);
            return Ok(result);
        }

        /// <summary>
        /// Delete an pachet
        /// </summary>
        /// <param name="id">Pachet id to delete</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = pachetService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}