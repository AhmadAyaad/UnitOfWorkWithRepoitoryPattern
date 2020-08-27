using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkSample.DTOS;
using UnitOfWorkSample.Entities;
using UnitOfWorkSample.UnitOfWork;

namespace UnitOfWorkSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerWithOrder(CreateCustomerOrderDto createCustomerOrderDto)
        {

            var customer = new Customer
            {
                CustomerID = createCustomerOrderDto.CustomerId,
                Address = createCustomerOrderDto.Address,
                Name = createCustomerOrderDto.Name
            };
            var orders = new List<Order>();
            orders = createCustomerOrderDto.Orders.ToList();
            try
            {
                _unitOfWork.CustomerRepo.Create(customer);
                await _unitOfWork.OrderRepo.AddAll(orders);
                await _unitOfWork.SaveChanges();
                return CreatedAtAction(nameof(CreateCustomerWithOrder), null);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest(e.Message);
            }


        }
    }
}
