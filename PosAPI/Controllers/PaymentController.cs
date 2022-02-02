using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosAPI.Dtos;
using PosAPI.Interfaces;
using PosAPI.Models;

namespace PosAPI.Controllers
{
    public class PaymentController : BaseController
    {
        //[Authorize]
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public PaymentController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("payments")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPayments()
        {
            var payments = await uow.PaymentRepository.GetPaymentsAsync();
            var paymentsDto = mapper.Map<IEnumerable<PaymentDto>>(payments);
            return Ok(paymentsDto);
        }

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPayment(PaymentDto paymentDto)
        {
            var payment = mapper.Map<Payment>(paymentDto);
            payment.LastUpdatedBy = 1;
            payment.LastUpdatedOn = DateTime.Now;
            uow.PaymentRepository.AddPayment(payment);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDto paymentDto)
        {
            if (id != paymentDto.Id)
                return BadRequest("Update not allowed");

            var paymentFromDB = await uow.PaymentRepository.FindPayment(id);
            if (paymentFromDB == null)
                return BadRequest("Update not allowed");
            
            paymentFromDB.LastUpdatedBy = 1;
            paymentFromDB.LastUpdatedOn = DateTime.Now;
            mapper.Map(paymentDto, paymentFromDB);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletePayment(int id)
        {
            uow.PaymentRepository.DeletePayment(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}