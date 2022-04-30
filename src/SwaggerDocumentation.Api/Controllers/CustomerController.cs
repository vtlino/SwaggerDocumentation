using Microsoft.AspNetCore.Mvc;
using SwaggerDocumentation.Domain.Enum;
using SwaggerDocumentation.Domain.Request.Body;
using SwaggerDocumentation.Domain.Request.CustomersQuery;
using SwaggerDocumentation.Domain.Request.Route;
using SwaggerDocumentation.Domain.Response;

namespace SwaggerDocumentation.Api.Controllers
{
    [Route("customers")]
    public class CustomerController : BaseController
    {
        /// <summary>Creates a Customer.</summary>
        /// <returns>Customer`s Id created</returns>
        /// <response code="201">Customer created</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerPostResponse))]
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequestBody requestBody)
        {
            var response = new CustomerPostResponse { Id = Guid.NewGuid() };
            return CreatedAtAction(nameof(GetCustomers), response.Id, response);
        }

        /// <summary>Lists Customers.</summary>
        /// <returns>Customers listed</returns>
        /// <response code="200">List of Customers</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomersGetResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] CustomersRequestQuery requestQuery)
        {
            return Ok(new CustomersGetResponse
            {
                Customers = new List<CustomerGetResponse> { GetCustomerMock() }
            });
        }

        /// <summary>Gets a specific Customer.</summary>
        /// <returns>Customer listed</returns>
        /// <response code="200">Customer</response>
        /// <response code="404">Customer not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerGetResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] CustomerIdRequestRoute customerRoute)
        {
            return Ok(GetCustomerMock());
        }

        /// <summary>Updates all fields of a specific Customer.</summary>
        /// <returns>Customer updated</returns>
        /// <response code="200">Customer updated</response>
        /// <response code="404">Customer not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerGetResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] CustomerIdRequestRoute customerRoute)
        {
            return Ok(GetCustomerMock());
        }

        /// <summary>Disables a specific Customer.</summary>
        /// <returns>Customer disabled</returns>
        /// <response code="200">Customer disable</response>
        /// <response code="404">Customer not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerGetResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [HttpPatch("{Id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] CustomerIdRequestRoute customerRoute)
        {
            return Ok(GetCustomerMock());
        }

        private static CustomerGetResponse GetCustomerMock()
        {
            return new CustomerGetResponse
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                Gender = GenderEnum.MASCULINE,
                Height = 180,
                Name = "Name",
                Occupation = "Occupation"
            };
        }
    }
}