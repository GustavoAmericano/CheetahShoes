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
        // GET api/values
        [HttpGet]
        public ActionResult<List<Shoe>> Get()
        {
            return _shoesService.getAllShoes();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _shoesService.Delete(id);
        }
    }
}
