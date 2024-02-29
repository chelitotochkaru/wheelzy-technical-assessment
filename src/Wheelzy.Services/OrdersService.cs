using System;
using Wheelzy.Infrastructure;
using Wheelzy.Services.DTO;
using Wheelzy.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wheelzy.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace Wheelzy.Services
{
	public class OrdersService : IOrdersService
	{
		#region Readonly Fields

		private readonly ApplicationDatabaseContext _dbContext;

		#endregion

		public OrdersService(ApplicationDatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

        #region Methods

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
			IQueryable<Order> orders = _dbContext.Orders
				.Include(o => o.Buyer)
				.Include(o => o.Status)
                .Include(o => o.Car)
					.ThenInclude(o => o.Make)
				.Include(o => o.Car)
					.ThenInclude(o => o.Model)
                .Include(o => o.Car)
                    .ThenInclude(o => o.Submodel)
                .Include(o => o.Customer)
                .AsQueryable();

			return await orders
                .Select(o => new OrderDTO()
				{
					OrderId = o.Id,
                    CreatedDate = o.CreatedDate,
                    CustomerName = o.Customer.Name,
					Make = o.Car.Make.Description,
					Model = o.Car.Model.Description,
					Submodel = o.Car.Submodel.Description,
					Year = o.Car.Year,
					ZipCode = o.Car.ZipCode,
					BuyerName = o.Buyer.Name,
					Quote = o.Buyer.Amount,
					Status = o.Status.Description,
					PickedUpDate = o.PickedUpDate
				})
				.AsNoTracking()
				.ToListAsync();
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders(DateTime dateFrom, DateTime dateTo, List<int> customerIds, List<int> statusIds, bool? isActive)
        {
            IQueryable<Order> orders = _dbContext.Orders
                .Include(o => o.Buyer)
                .Include(o => o.Status)
                .Include(o => o.Car)
                    .ThenInclude(c => c.Make)
                .Include(o => o.Car)
                    .ThenInclude(o => o.Model)
                .Include(o => o.Car)
                    .ThenInclude(o => o.Submodel)
                .Include(o => o.Customer)
                .AsQueryable();

            orders = orders.Where(o => o.CreatedDate.Date >= dateFrom.Date && o.CreatedDate.Date <= dateTo.Date);

            if (customerIds.Any())
                orders = orders.Where(o => customerIds.Contains(o.CustomerId));

            if (statusIds.Any())
                orders = orders.Where(o => statusIds.Contains(o.StatusId));

            if (isActive.HasValue)
                orders = orders.Where(o => o.Active == isActive);

            return await orders
                .Select(o => new OrderDTO()
                {
                    OrderId = o.Id,
                    CreatedDate = o.CreatedDate,
                    CustomerName = o.Customer.Name,
                    Make = o.Car.Make.Description,
                    Model = o.Car.Model.Description,
                    Submodel = o.Car.Submodel.Description,
                    Year = o.Car.Year,
                    ZipCode = o.Car.ZipCode,
                    BuyerName = o.Buyer.Name,
                    Quote = o.Buyer.Amount,
                    Status = o.Status.Description,
                    PickedUpDate = o.PickedUpDate
                })
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}

