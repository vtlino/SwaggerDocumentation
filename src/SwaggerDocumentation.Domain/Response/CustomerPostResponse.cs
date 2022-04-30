using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Response
{
    public class CustomerPostResponse
    {
        /// <summary>Customer`s Id in system</summary>
        /// <example>68c91192-2d83-4eff-b273-cb55626671a3</example>
        [Required]
        public Guid Id { get; set; }
    }
}