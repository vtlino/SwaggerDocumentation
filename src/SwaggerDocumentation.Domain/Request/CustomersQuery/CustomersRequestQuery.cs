using SwaggerDocumentation.Domain.Enum;
using SwaggerDocumentation.Domain.Request.Pagination;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Request.CustomersQuery
{
    public class CustomersRequestQuery : RequestPagination
    {
        /// <summary>Customer`s name or part of it</summary>
        /// <example>John</example>
        [StringLength(150)]
        public string? Name { get; set; }
        /// <summary>Customer`s nickname or part of it</summary>
        /// <example>Little</example>
        [StringLength(150)]
        public string? NickName { get; set; }
        /// <summary>Customer`s height (in centimeters)</summary>
        /// <example>180</example>
        [Range(50, 250)]
        public int? Height { get; set; }
        /// <summary>Customer`s gender</summary>
        /// <example>MASCULINE</example>
        public GenderEnum? Gender { get; set; }
    }
}