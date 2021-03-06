﻿using System.ComponentModel.DataAnnotations;

namespace Swagger_Test.Models
{
    /// <summary>
    /// Testing POCO model
    /// </summary>
    public class ViewModelTest
    {
        /// <summary>
        /// The super ID that will be used
        /// </summary>
        /// <example>123</example>
        public int Id { get; set; }

        /// <summary>
        /// Who needs a name?
        /// </summary>
        public string Name { get; set; }

        public string abd { get; set; }
        public string xyz { get; set; }
        public string cde { get; set; }

        [MinLength(3)]
        [MaxLength(5)]
        public string bcd { get; set; }

    }
}