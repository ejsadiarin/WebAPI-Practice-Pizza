using WebAPI_Practice.Models;
using WebAPI_Practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Practice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
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
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            // returns IActionResult response
            // IActionResult lets client know if request succeeded and provides ID of newly created pizza
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);

        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            // updates pizza and returns result
            // returns 204 NoContent HTTP status code if success, 404 BadRequest if not
            if (id != pizza.Id) return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null) return NotFound();

            PizzaService.Update(pizza);
            return NoContent();
        }
        
        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // deletes pizza by id and returns result
            // returns 204 NoContent HTTP status code if success, 404 NotFound if not
            var pizza = PizzaService.Get(id);

            if (pizza is null) return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

    }
}
