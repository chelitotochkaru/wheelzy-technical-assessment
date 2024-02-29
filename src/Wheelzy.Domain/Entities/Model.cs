using System;
namespace Wheelzy.Domain.Entities
{
	public class Model
	{
		public int Id { get; set; }
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		public string Description { get; set; }
	}
}

