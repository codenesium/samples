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
	public abstract class AbstractSalesPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesPerson>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesPerson> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<SalesPerson> Create(SalesPerson item)
		{
			this.Context.Set<SalesPerson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesPerson item)
		{
			var entity = this.Context.Set<SalesPerson>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<SalesPerson>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			SalesPerson record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<SalesPerson> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<SalesPerson>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>().Where(x => x.SalesPersonID == salesPersonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		public async virtual Task<List<Store>> StoresBySalesPersonID(int salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Store>().Where(x => x.SalesPersonID == salesPersonID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Store>();
		}

		public async virtual Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID)
		{
			return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.TerritoryID == territoryID);
		}

		protected async Task<List<SalesPerson>> Where(
			Expression<Func<SalesPerson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesPerson, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<SalesPerson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesPerson>();
		}

		private async Task<SalesPerson> GetById(int businessEntityID)
		{
			List<SalesPerson> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>bb52c5cf5871023f5edca3deefaf8a53</Hash>
</Codenesium>*/