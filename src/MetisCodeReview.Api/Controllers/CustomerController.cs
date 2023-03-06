using Mediator.Net;
using MetisCodeReview.Messages.Commands.Customers;
using MetisCodeReview.Messages.Requests.Customers;
using Microsoft.AspNetCore.Mvc;

namespace MetisCodeReview.Api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetCustomerResponse), 200)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var response = await _mediator.RequestAsync<GetCustomerRequest, GetCustomerResponse>(
                new GetCustomerRequest { CustomerId = id });

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateCustomerResponse), 200)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand command)
        {
            var response = await _mediator.SendAsync<CreateCustomerCommand, CreateCustomerResponse>(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand command)
        {
            await _mediator.SendAsync(command);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCustomerCommand command)
        {
            await _mediator.SendAsync(command);
            return Ok();
        }
    }
}