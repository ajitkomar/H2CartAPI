using HouseHoldCart.Application.HouseHoldItems.Commands;
using HouseHoldCart.Application.HouseHoldItems.Queries;
using HouseHoldCart.Models.HouseHoldItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseHoldCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseHoldItemsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<HouseHoldItem>>> Get()
        {
            var items = await _mediator.Send(new SearchHouseHoldItemsQuery());
            return Ok(items);
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult<HouseHoldItem>> Create([FromBody] HouseHoldItem item)
        {
            var createdItem = await _mediator.Send(new CreateHouseHoldItemCommand(item));
            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }
    }
}
