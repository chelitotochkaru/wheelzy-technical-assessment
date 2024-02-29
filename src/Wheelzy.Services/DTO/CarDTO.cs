﻿using System;
namespace Wheelzy.Services.DTO
{
	public class OrderDTO
	{
		public int OrderId { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CustomerName { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string Submodel { get; set; }
		public int Year { get; set; }
		public int ZipCode { get; set; }
		public string BuyerName { get; set; }
		public decimal Quote { get; set; }
		public string Status { get; set; }
		public DateTime? PickedUpDate { get; set; }
	}
}

