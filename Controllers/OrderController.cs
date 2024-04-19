﻿using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Order;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(OrderSchema schema)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("");
            }
            try
            {
                var userId = JwtToken.GetIdFromClaim(HttpContext);

                var orderEntity = new OrderEntity
                {
                    AppUserId = userId,
                    PaymentDetailId = schema.PaymentDetailId,
                    AddressId = schema.AddressId,
                    TotalPrice = schema.TotalPrice,
                    Cancelled = false,
                    CancelledMessage = schema.CancelledMessage,
                };
                _context.Add(orderEntity);
                await _context.SaveChangesAsync();
                return Ok(orderEntity.Id);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
        [HttpGet("getOrderHistory")]
        [Authorize]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            try
            {

          
            var userId = JwtToken.GetIdFromClaim(HttpContext);
            // Fetch entities from database
            List<OrderEntity> orderEntities = await _context.Orders
                                                            .Where(o => o.AppUserId == userId)
                                                            .ToListAsync();

            // Convert entities to DTOs
            List<OrderDto> orders = orderEntities.Select(entity => (OrderDto)entity).ToList();

            return Ok(orders);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
        
    }
}