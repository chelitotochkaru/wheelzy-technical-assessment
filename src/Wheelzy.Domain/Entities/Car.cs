using System;
namespace Wheelzy.Domain.Entities
{
	public class Car
	{
		public int Id { get; set; }
		public int Year { get; set; }
		public int MakeId { get; set; }
		public Brand Make { get; set; }
		public int ModelId { get; set; }
		public Model Model { get; set; }
        public int SubmodelId { get; set; }
        public Submodel Submodel { get; set; }
		public int ZipCode { get; set; }
	}
}

