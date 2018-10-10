using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheetahShoes.Core.ApplicationService;
using CheetahShoes.Core.DomainService;
using CheetahShoes.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CheetahShoes.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeService _shoesService;

        public ShoesController(IShoeService shoeService)
        {
            _shoesService = shoeService;
        }
        // GET api/values GET ALL WITH FILTER :-)
        [HttpGet]
        public ActionResult<List<Shoe>> Get([FromQuery] Filter filter)
        {
            return _shoesService.getAllShoes(filter);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Shoe> Get(int id)
        {
            return _shoesService.ReadById(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Shoe> Post([FromBody] Shoe shoe)
        {
            try
            {
                return _shoesService.Create(shoe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Shoe> Put(int id, [FromBody] Shoe shoeUpdate)
        {
            if(id != shoeUpdate.Id) return BadRequest("Invalid ID!");

            try
            {
                return _shoesService.Update(shoeUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _shoesService.Delete(id);
        }
    }
}
