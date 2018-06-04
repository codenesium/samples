using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShipMethodRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractShipMethodRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ShipMethod>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ShipMethod> Get(int shipMethodID)
		{
			return await this.GetById(shipMethodID);
		}

		public async virtual Task<ShipMethod> Create(ShipMethod item)
		{
			this.Context.Set<ShipMethod>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ShipMethod item)
		{
			var entity = this.Context.Set<ShipMethod>().Local.FirstOrDefault(x => x.ShipMethodID == item.ShipMethodID);
			if (entity == null)
			{
				this.Context.Set<ShipMethod>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
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

		public async Task<ShipMethod> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<ShipMethod>> Where(Expression<Func<ShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ShipMethod> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
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
    <Hash>77ff7122f3c710dd137601a4e1be4458</Hash>
</Codenesium>*/