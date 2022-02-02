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

namespace PosAPI.Controllers
{
    //[Authorize]
    public class SupplierController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public SupplierController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("suppliers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await uow.SupplierRepository.GetSuppliersAsync();
            var suppliersDto = mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            return Ok(suppliersDto);
        }

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddSupplier(SupplierDto supplierDto)
        {
            var supplier = mapper.Map<Supplier>(supplierDto);
            supplier.LastUpdatedBy = 1;
            supplier.LastUpdatedOn = DateTime.Now;
            uow.SupplierRepository.AddSupplier(supplier);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateSupplier(int id, SupplierDto supplierDto)
        {
            if(id != supplierDto.Id)
                return BadRequest("Update not allowed");

            var supplierFromDb = await uow.SupplierRepository.FindSupplier(id);

            if (supplierFromDb == null)
                return BadRequest("Update not allowed");
            
            supplierFromDb.LastUpdatedBy = 1;
            supplierFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(supplierDto, supplierFromDb);
        
            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            uow.SupplierRepository.DeleteSupplier(id);
            await uow.SaveAsync();
            return Ok(id);
        }

    }
}