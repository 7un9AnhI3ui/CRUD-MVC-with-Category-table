using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
//using crud.Data;
//using Microsoft.EntityFrameworkCore;

namespace crud.Models
{

    public class Product
	{
        [Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Color { get; set; }

        //Category
        public int CategoryId{ get; set; }
        [ForeignKey("CategoryId")]

        public Category? Category { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

