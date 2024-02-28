using System;
namespace Wheelzy.Domain.Entities
{
	public class Tracking
	{
		public int Id { get; set; }
		public int SellId { get; set; }
		public Sell Sell {get;set;}
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime Timestamp { get; set; }
	}
}

