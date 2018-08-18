using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShipMethodRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractShipMethodRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ShipMethod>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async Task<ShipMethod> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async virtual Task<List<PurchaseOrderHeader>> PurchaseOrderHeaders(int shipMethodID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<PurchaseOrderHeader>().Where(x => x.ShipMethodID == shipMethodID).AsQueryable().Skip(offset).Take(limit).ToListAsync<PurchaseOrderHeader>();
		}

		protected async Task<List<ShipMethod>> Where(
			Expression<Func<ShipMethod, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ShipMethod, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ShipMethodID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ShipMethod>();
			}
			else
			{
				return await this.Context.Set<ShipMethod>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ShipMethod>();
			}
		}

		private async Task<ShipMethod> GetById(int shipMethodID)
		{
			List<ShipMethod> records = await this.Where(x => x.ShipMethodID == shipMethodID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f62821fd61f2810916a7ed8451f462cd</Hash>
</Codenesium>*/