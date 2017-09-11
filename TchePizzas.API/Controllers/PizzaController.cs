using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TchePizzas.Domain.Repositories;

namespace TchePizzas.API.Controllers
{
    public class PizzaController : Controller
    {
        readonly IPizzaRepository _pizzaRepository;

        public PizzaController(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        // GET: api/values
        [HttpGet]
        [Route("v1/Pizza")]
        public IActionResult Get()
        {
            
            return Ok(_pizzaRepository.Get(Guid.NewGuid()));

            
        }

      
    }
}
