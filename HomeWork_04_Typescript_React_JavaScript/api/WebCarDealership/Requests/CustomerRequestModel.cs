﻿using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class CustomerRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
