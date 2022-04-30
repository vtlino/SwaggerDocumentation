using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Request.Pagination
{
    public class RequestPagination
    {
        /// <summary>Number of the page wanted (first is zero)</summary>
        /// <example>0</example>
        [Required, Range(0, 99999)]
        public int Page { get; set; }
        /// <summary>Number of elements by page</summary>
        /// <example>1</example>
        [Required, Range(1,200)]
        public int PageSize { get; set; }
    }
}