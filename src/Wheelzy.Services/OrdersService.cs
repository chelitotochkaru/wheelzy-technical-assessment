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
				.Include(s => s.Buyer)
				.Include(s => s.Status)
                .Include(s => s.Car)
					.ThenInclude(c => c.Make)
				.Include(s => s.Car)
					.ThenInclude(c => c.Model)
                .Include(s => s.Car)
                    .ThenInclude(c => c.Submodel)
                .AsQueryable();

			return await orders
                .Select(s => new OrderDTO()
				{
					SellId = s.Id,
					Make = s.Car.Make.Description,
					Model = s.Car.Model.Description,
					Submodel = s.Car.Submodel.Description,
					Year = s.Car.Year,
					ZipCode = s.Car.ZipCode,
					BuyerName = s.Buyer.Name,
					Quote = s.Buyer.Amount,
					Status = s.Status.Description,
					PickedUpDate = s.PickedUpDate
				})
				.AsNoTracking()
				.ToListAsync();
        }

        #endregion
    }
}

