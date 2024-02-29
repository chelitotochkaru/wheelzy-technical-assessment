﻿using System;
namespace Wheelzy.Domain.Entities
{
	public class Tracking
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public Order Order {get;set;}
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime Timestamp { get; set; }
	}
}

