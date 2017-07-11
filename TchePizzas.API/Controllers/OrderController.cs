﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TchePizzas.Domain.Commands.Handler;
using TchePizzas.Domain.Commands.Input;
using TchePizzas.Domain.Repositories;

namespace TchePizzas.API.Controllers
{
    public class OrderController : Controller
    {
        //Variables//
        readonly IOrderRepository _orderRepository;
        readonly OrderCommandHandler _handler;

        public OrderController(IOrderRepository orderRepository, OrderCommandHandler handler)
        {
            _orderRepository = orderRepository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/Order")]
        public IActionResult Get()
        {
            var result =  _orderRepository.GetAll();

            if(result.Count() == 0)
				return NoContent();

            return Ok(_orderRepository.GetAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _orderRepository.Get(id);
            if (result == null)
                return NoContent();

            return Ok(new { 
                success = true, 
                data = result 
            });
        }

		[HttpPost]
		[Route("v1/Order/Registered")]
        public ActionResult Post([FromBody]RegisterOrderCommand command)
		{
			var result = _handler.Handle(command);

			//Verify if already notifications
			if (_handler.Notifications.Count > 0)
			{
				return BadRequest(new
				{
					success = false,
					errors = _handler.Notifications
				});
			}

			return Ok(new
			{
				success = true,
				data = result
			});
		}

        [HttpPost]
        [Route("v1/Order/NoRegister")]
        public ActionResult Post([FromBody]RegisterOrderWithoutCustomerCommand command)
        {
            var result = _handler.Handle(command);

            //Verify if already notifications
            if(_handler.Notifications.Count > 0){
                return BadRequest(new {
                    success = false,
                    errors = _handler.Notifications
                });
            }

            return Ok(new {
                success = true,
                data = result
            });
        }
    }
}
