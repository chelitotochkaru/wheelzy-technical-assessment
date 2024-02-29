using Wheelzy.Services.DTO;

namespace Wheelzy.Services.Interfaces
{
    public interface ISellsService
	{
		public Task<IEnumerable<CarDTO>> GetCars();
	}
}

