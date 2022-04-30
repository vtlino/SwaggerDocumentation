﻿using SwaggerDocumentation.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SwaggerDocumentation.Domain.Request.Body
{
    public class CustomerRequestBody
    {
        /// <summary>Customer`s name</summary>
        /// <example>John Bean</example>
        [Required, StringLength(150, MinimumLength = 5)]
        public string Name { get; set; }
        /// <summary>Customer`s nickname</summary>
        /// <example>Little John</example>
        [StringLength(150, MinimumLength = 5)]
        public string? NickName { get; set; }
        /// <summary>Customer`s occupation</summary>
        /// <example>Manager</example>
        [Required, StringLength(100, MinimumLength = 5)]
        public string Occupation { get; set; }
        /// <summary>Customer`s birth date (yyyy-MM-dd)</summary>
        /// <example>2000-01-01</example>
        [Required]
        public DateTime BirthDate { get; set; }
        /// <summary>Customer`s gender</summary>
        /// <example>John Bean</example>
        [Required]
        public GenderEnum Gender { get; set; }
        /// <summary>Customer`s height (in centimeters)</summary>
        /// <example>180</example>
        [Required, Range(50, 250)]
        public int Height { get; set; }
    }
}