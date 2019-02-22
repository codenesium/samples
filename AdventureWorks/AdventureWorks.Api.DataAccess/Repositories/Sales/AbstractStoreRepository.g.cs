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
	public abstract class AbstractStoreRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractStoreRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Store>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.BusinessEntityID == query.ToInt() ||
				                  x.Demographic.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query) ||
				                  x.Rowguid == query.ToGuid() ||
				                  x.SalesPersonID == query.ToNullableInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Store> Get(int businessEntityID)
		{
			return await this.GetById(businessEntityID);
		}

		public async virtual Task<Store> Create(Store item)
		{
			this.Context.Set<Store>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Store item)
		{
			var entity = this.Context.Set<Store>().Local.FirstOrDefault(x => x.BusinessEntityID == item.BusinessEntityID);
			if (entity == null)
			{
				this.Context.Set<Store>().Attach(item);
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
			Store record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Store>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_Store_rowguid.
		public async virtual Task<Store> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Store>()
			       .Include(x => x.SalesPersonIDNavigation)

			       .FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Non-unique constraint IX_Store_SalesPersonID.
		public async virtual Task<List<Store>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SalesPersonID == salesPersonID, limit, offset);
		}

		// Non-unique constraint PXML_Store_Demographics.
		public async virtual Task<List<Store>> ByDemographic(string demographic, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.Demographic == demographic, limit, offset);
		}

		// Foreign key reference to this table Customer via storeID.
		public async virtual Task<List<Customer>> CustomersByStoreID(int storeID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Customer>()
			       .Include(x => x.StoreIDNavigation)
			       .Where(x => x.StoreID == storeID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Customer>();
		}

		// Foreign key reference to table SalesPerson via salesPersonID.
		public async virtual Task<SalesPerson> SalesPersonBySalesPersonID(int? salesPersonID)
		{
			return await this.Context.Set<SalesPerson>()
			       .SingleOrDefaultAsync(x => x.BusinessEntityID == salesPersonID);
		}

		protected async Task<List<Store>> Where(
			Expression<Func<Store, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Store, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.BusinessEntityID;
			}

			return await this.Context.Set<Store>()
			       .Include(x => x.SalesPersonIDNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Store>();
		}

		private async Task<Store> GetById(int businessEntityID)
		{
			List<Store> records = await this.Where(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>44a3cd570af82daec2eabdc18e60a993</Hash>
</Codenesium>*/