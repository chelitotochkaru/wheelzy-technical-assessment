using Wheelzy.Services.DTO;

namespace Wheelzy.Services.Interfaces
{
    public interface IOrdersService
	{
		public Task<IEnumerable<OrderDTO>> GetOrders();
        public Task<IEnumerable<OrderDTO>> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive);
    }
}

