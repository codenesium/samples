using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShipMethodRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShipMethodRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOShipMethod> Get(int shipMethodID)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			return this.Mapper.ShipMethodMapEFToPOCO(record);
		}

		public async virtual Task<POCOShipMethod> Create(
			ApiShipMethodModel model)
		{
			ShipMethod record = new ShipMethod();

			this.Mapper.ShipMethodMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ShipMethod>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ShipMethodMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int shipMethodID,
			ApiShipMethodModel model)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shipMethodID}");
			}
			else
			{
				this.Mapper.ShipMethodMapModelToEF(
					shipMethodID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int shipMethodID)
		{
			ShipMethod record = await this.GetById(shipMethodID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ShipMethod>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOShipMethod> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOShipMethod>> Where(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShipMethod> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOShipMethod>> SearchLinqPOCO(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShipMethod> response = new List<POCOShipMethod>();
			List<ShipMethod> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ShipMethodMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ShipMethod>> SearchLinqEF(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}
			return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShipMethod>();
		}

		private async Task<List<ShipMethod>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ShipMethod.ShipMethodID)} ASC";
			}

			return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ShipMethod>();
		}

		private async Task<ShipMethod> GetById(int shipMethodID)
		{
			List<ShipMethod> records = await this.SearchLinqEF(x => x.ShipMethodID == shipMethodID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1c16f4fd2f142a81dfd388d574ba732f</Hash>
</Codenesium>*/