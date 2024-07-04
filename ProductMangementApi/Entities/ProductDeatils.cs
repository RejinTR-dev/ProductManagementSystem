﻿using System.ComponentModel.DataAnnotations;

namespace ProductManagementAPI.Entities
{
    public class ProductDeatils
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quandity { get; set; }
    }
}
