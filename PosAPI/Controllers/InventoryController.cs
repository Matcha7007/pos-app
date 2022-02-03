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
    public class InventoryController : BaseController
    {
        //[Authorize]
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public InventoryController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("inventories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInventories()
        {
            var invntories = await uow.InventoryRepository.GetInventoriesAsync();
            var inventoriesDto = mapper.Map<IEnumerable<InventoryDto>>(invntories);
            return Ok(inventoriesDto);
        }

        [HttpPost("post")]
        [AllowAnonymous]
        public async Task<IActionResult> AddInventory(InventoryDto inventoryDto)
        {
            var inventory = mapper.Map<Inventory>(inventoryDto);
            inventory.LastUpdatedBy = 1;
            inventory.LastUpdatedOn = DateTime.Now;
            uow.InventoryRepository.AddInventory(inventory);

            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("put/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateInventory(int id, InventoryDto inventoryDto)
        {
            if (id != inventoryDto.Id)
                return BadRequest("Update not allowed");
            
            var inventoryFromDB = await uow.InventoryRepository.FindInventory(id);
            if (inventoryFromDB == null)
                return BadRequest("Update not allowed");

            inventoryFromDB.LastUpdatedBy = 1;
            inventoryFromDB.LastUpdatedOn = DateTime.Now;
            mapper.Map(inventoryDto, inventoryFromDB);

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            uow.InventoryRepository.DeleteInventory(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}