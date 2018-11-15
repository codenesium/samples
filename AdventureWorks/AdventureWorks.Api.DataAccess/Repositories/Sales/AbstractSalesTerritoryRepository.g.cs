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
	public abstract class AbstractSalesTerritoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesTerritoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesTerritory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesTerritory> Get(int territoryID)
		{
			return await this.GetById(territoryID);
		}

		public async virtual Task<SalesTerritory> Create(SalesTerritory item)
		{
			this.Context.Set<SalesTerritory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesTerritory item)
		{
			var entity = this.Context.Set<SalesTerritory>().Local.FirstOrDefault(x => x.TerritoryID == item.TerritoryID);
			if (entity == null)
			{
				this.Context.Set<SalesTerritory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int territoryID)
		{
			SalesTerritory record = await this.GetById(territoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTerritory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SalesTerritory> ByName(string name)
		{
			return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<SalesTerritory> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		public async virtual Task<List<Customer>> CustomersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Customer>().Where(x => x.TerritoryID == territoryID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Customer>();
		}

		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>().Where(x => x.TerritoryID == territoryID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		public async virtual Task<List<SalesPerson>> SalesPersonsByTerritoryID(int territoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesPerson>().Where(x => x.TerritoryID == territoryID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesPerson>();
		}

		protected async Task<List<SalesTerritory>> Where(
			Expression<Func<SalesTerritory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesTerritory, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.TerritoryID;
			}

			return await this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesTerritory>();
		}

		private async Task<SalesTerritory> GetById(int territoryID)
		{
			List<SalesTerritory> records = await this.Where(x => x.TerritoryID == territoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c518c1e1651ea1197f66a994f58c2322</Hash>
</Codenesium>*/