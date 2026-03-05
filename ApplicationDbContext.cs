using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.API.Models;
using VendingMachine.API.Services;

namespace VendingMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public InventoryController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _inventoryService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItem([FromBody] Item item)
        {
            if (item == null || string.IsNullOrEmpty(item.Name) || item.Price <= 0 || item.Stock < 0)
            {
                return BadRequest("Invalid item data.");
            }

            var createdItem = await _inventoryService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItems), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Item>> UpdateItem(int id, [FromBody] Item item)
        {
            if (id != item.Id || item == null || string.IsNullOrEmpty(item.Name) || item.Price <= 0 || item.Stock < 0)
            {
                return BadRequest("Invalid item data.");
            }

            var updatedItem = await _inventoryService.UpdateItemAsync(item);
            if (updatedItem == null)
            {
                return NotFound();
            }

            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _inventoryService.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}