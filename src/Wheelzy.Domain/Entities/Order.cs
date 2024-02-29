using System;
namespace Wheelzy.Domain.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public Car Car { get; set; }
		public int StatusId { get; set; }
		public Status Status { get; set; }
		public int BuyerId { get; set; }
		public Buyer Buyer { get; set; }
        public DateTime PickedUpDate { get; set; }
    }
}

