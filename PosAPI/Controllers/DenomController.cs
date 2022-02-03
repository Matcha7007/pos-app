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
    public class DenomController : BaseController
    {
        //[Authorize]
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public DenomController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("denoms")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDenoms()
        {
            var denoms = await uow.DenomRepository.GetDenomsAsync();
            var denomsDto = mapper.Map<IEnumerable<DenomDto>>(denoms);
            return Ok(denomsDto);
        }

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddDenom(DenomDto denomDto)
        {
            var denom = mapper.Map<Denom>(denomDto);
            denom.LastUpdatedBy = 1;
            denom.LastUpdatedOn = DateTime.Now;
            uow.DenomRepository.AddDenom(denom);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("put/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDenom(int id, DenomDto denomDto)
        {
            if (id != denomDto.Id)
                return BadRequest("Update not allowed");

            var denomFromDB = await uow.DenomRepository.FindDenom(id);
            if (denomFromDB == null)
                return BadRequest("Update not allowed");

            denomFromDB.LastUpdatedBy = 1;
            denomFromDB.LastUpdatedOn = DateTime.Now;
            mapper.Map(denomDto, denomFromDB);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDenom(int id)
        {
            uow.DenomRepository.DeleteDenom(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}