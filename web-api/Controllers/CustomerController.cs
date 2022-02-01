using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Dtos;
using web_api.Interfaces;
using web_api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CustomerController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers =  await uow.CustomerRepository.GetCustomersAsync();
            var customersDto = mapper.Map<IEnumerable<CustomerDtos>>(customers);
            return Ok(customersDto);
        }

        [HttpPost("post")]
        public async Task<IActionResult> AddCustomer(CustomerDtos customerDtos)
        {
            var customer = mapper.Map<Customer>(customerDtos);
            customer.LastUpdateOn = DateTime.Now;
            customer.LastUpdateBy = 1;
            uow.CustomerRepository.AddCustomer(customer);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDtos customerDto)
        {
            if (id != customerDto.Id)
                return BadRequest("Id parameters is different");
            
            var customerfromDB = await uow.CustomerRepository.FindCustomer(id);
            if (customerfromDB == null)
                return BadRequest("Update not allowed");
            
            customerfromDB.LastUpdateOn = DateTime.Now;
            customerfromDB.LastUpdateBy = 1;
            mapper.Map(customerDto, customerfromDB);
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            uow.CustomerRepository.DeleteCustomer(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}