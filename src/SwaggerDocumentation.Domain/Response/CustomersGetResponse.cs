using SwaggerDocumentation.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Response
{
    public class CustomersGetResponse : PaginationResponse
    {
        /// <summary>List of Customers</summary>
        [Required]
        public List<CustomerGetResponse> Customers { get; set; }
    }
}