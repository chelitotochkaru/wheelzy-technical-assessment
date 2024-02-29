using System;
using Wheelzy.Infrastructure;
using Wheelzy.Services.DTO;
using Wheelzy.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wheelzy.Domain.Entities;

namespace Wheelzy.Services
{
	public class SellsService : ISellsService
	{
		#region Readonly Fields

		private readonly ApplicationDatabaseContext _dbContext;

		#endregion

		public SellsService(ApplicationDatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<IEnumerable<CarDTO>> GetCars()
        {
			IQueryable<Sell> sells = _dbContext.Sells
				.Include(s => s.Buyer)
				.Include(s => s.Status)
                .Include(s => s.Car)
					.ThenInclude(c => c.Make)
				.Include(s => s.Car)
					.ThenInclude(c => c.Model)
                .Include(s => s.Car)
                    .ThenInclude(c => c.Submodel)
                .AsQueryable();

			return await sells
                .Select(s => new CarDTO()
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
    }
}

