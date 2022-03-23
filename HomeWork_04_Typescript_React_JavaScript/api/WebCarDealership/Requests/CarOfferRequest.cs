﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class CarOfferRequestModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required] 
        [Range(0, 10000)]
        public int AvailableStock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]

        public decimal DiscountPercentage { get; set; }

        [Required]
        public string Image { get; set; }

    }
}
