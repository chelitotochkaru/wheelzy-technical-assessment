using System;
namespace Wheelzy.Domain.Entities
{
	public class Submodel
	{
		public int Id { get; set; }
		public int ModelId { get; set; }
		public Model Model { get; set; }
		public string Description { get; set; }
	}
}

