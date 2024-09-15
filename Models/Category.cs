using System;
using Microsoft.Extensions.Hosting;
//using crud.Data;
//using Microsoft.EntityFrameworkCore;

namespace crud.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
