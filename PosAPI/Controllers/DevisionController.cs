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
    public class DevisionController : BaseController
    {
        //[Authorize]
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public DevisionController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("devisions")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDevisions()
        {
            var devisions = await uow.DevisionRepository.GetDevisionsAsync();
            var devisionsDto =  mapper.Map<IEnumerable<DevisionDto>>(devisions);
            return Ok(devisionsDto);
        }   

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddDevision(DevisionDto devisionDto)
        {
            var devision = mapper.Map<Devision>(devisionDto);
            devision.LastUpdatedBy = 1;
            devision.LastUpdatedOn = DateTime.Now;
            uow.DevisionRepository.AddDevision(devision);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateDevision(int id, DevisionDto devisionDto)
        {
            if(id != devisionDto.Id)
                return BadRequest("Update not allowed");

            var devisionFromDb = await uow.DevisionRepository.FindDevision(id);

            if (devisionFromDb == null)
                return BadRequest("Update not allowed");
            
            devisionFromDb.LastUpdatedBy = 1;
            devisionFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(devisionDto, devisionFromDb);
        
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteDevision(int id)
        {
            uow.DevisionRepository.DeleteDevision(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}