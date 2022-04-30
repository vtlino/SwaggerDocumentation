using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Response
{
    public class ErrorResponse
    {
        /// <summary>List of errors</summary>
        [Required]
        public List<ErrorData> Errors { get; set; } = new List<ErrorData>();
    }

    public class ErrorData
    {
        /// <summary>Error code</summary>
        /// <example>EBR000</example>
        [Required, StringLength(6, MinimumLength = 6)]
        public string Code { get; set; }
        /// <summary>Error message</summary>
        /// <example>Parameter xpto invalid.</example>
        [Required]
        public string Message { get; set; }
    }
}