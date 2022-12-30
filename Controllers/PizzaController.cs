using WebAPI_Practice.Models;
using WebAPI_Practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
        // GET id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza == null) return NotFound();

            return pizza;
        }
        // POST action

        // PUT action

        // DELETE action

    }
}
