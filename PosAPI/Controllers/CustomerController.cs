using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PosAPI.Dtos;
using PosAPI.Interfaces;
using PosAPI.Models;
//using PosAPI.Models;
// >> step 1 

namespace PosAPI.Controllers
{
    //[Authorize]
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public CustomerController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("customers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await uow.CustomerRepository.GetCustomersAsync();
            var customersDto = mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customersDto);
        }

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddCustomer(CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            customer.LastUpdatedBy = 1;
            customer.LastUpdatedOn = DateTime.Now;
            uow.CustomerRepository.AddCustomer(customer);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if(id != customerDto.Id)
                return BadRequest("Update not allowed");

            var customerFromDb = await uow.CustomerRepository.FindCustomer(id);

            if (customerFromDb == null)
                return BadRequest("Update not allowed");
            
            customerFromDb.LastUpdatedBy = 1;
            customerFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(customerDto, customerFromDb);
        
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            uow.CustomerRepository.DeleteCustomer(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}