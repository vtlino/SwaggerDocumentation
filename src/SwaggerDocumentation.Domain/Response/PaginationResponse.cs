using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Response
{
    public class PaginationResponse
    {     
        /// <summary>Pagination content</summary>
        [Required]
        public PaginationData Pagination { get; set; }
    }

    public class PaginationData
    {
        /// <summary>Total number of elements wanted</summary>
        /// <example>180</example>
        [Required, Range(0, 9999999)]
        public long TotalCount { get; set; }
        /// <summary>Page number wanted</summary>
        /// <example>1</example>
        [Required, MaxLength(9999999)] 
        public int PageCurrent { get; set; }
        /// <summary>Number of elements in a page</summary>
        /// <example>20</example>
        [Required, Range(1, 200)] 
        public int PageSize { get; set; }
    }
}