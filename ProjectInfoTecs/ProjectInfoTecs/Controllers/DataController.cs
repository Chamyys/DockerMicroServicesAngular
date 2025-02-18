using Microsoft.AspNetCore.Mvc;
using ProjectInfoTecs.ItemService;
using ProjectInfoTecs.Models;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IItemService _itemService;

        public DataController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = _itemService.GetItems();
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Remove([FromBody] ApplicationEntity data)
        {
            _itemService.RemoveItem(data);
            return Ok(new { Message = "Ok!", Data = data });
        }
        [HttpGet]
        public IActionResult BackUp()
        {
            _itemService.BackUp();
            return Ok(new { Message = "Ok!!"});
        }
    }
}