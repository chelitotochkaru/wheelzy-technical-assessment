using Wheelzy.Services.DTO;

namespace Wheelzy.Services.Interfaces
{
    public interface IOrdersService
	{
		public Task<IEnumerable<OrderDTO>> GetOrders();
	}
}

