using HouseHoldCart.Application.HouseHoldItems.Commands;
using HouseHoldCart.Application.HouseHoldItems.Queries;
using HouseHoldCart.Models.HouseHoldItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseHoldCart.Controllers
{
    public class OrderController(IMediator _mediator) : ControllerBase
    {
        //[HttpGet]
        //public async Task<ActionResult<List<HouseHoldItem>>> Get()
        //{
        //    var items = await _mediator.Send(new SearchHouseHoldItemsQuery());
        //    return Ok(items);
        //}

        [HttpPost]
        public async Task<ActionResult<HouseHoldItem>> Post([FromBody] HouseHoldItem item)
        {
            var createdItem = await _mediator.Send(new CreateHouseHoldItemCommand(item));
            return CreatedAtAction(nameof(Get), new { id = createdItem.Id }, createdItem);
        }
    }
}
