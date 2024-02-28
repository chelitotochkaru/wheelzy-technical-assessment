using System;
namespace Wheelzy.Domain.Entities
{
	public class Car
	{
		public int Id { get; set; }
		public int Year { get; set; }
		public int MakeId { get; set; }
		public Brand Make { get; set; }
		public string Model { get; set; }
		public string Submodel { get; set; }
		public int ZipCode { get; set; }
	}
}

