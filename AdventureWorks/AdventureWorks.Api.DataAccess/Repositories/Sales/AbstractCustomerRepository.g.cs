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
	public abstract class AbstractCustomerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCustomerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Customer>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Customer> Get(int customerID)
		{
			return await this.GetById(customerID);
		}

		public async virtual Task<Customer> Create(Customer item)
		{
			this.Context.Set<Customer>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Customer item)
		{
			var entity = this.Context.Set<Customer>().Local.FirstOrDefault(x => x.CustomerID == item.CustomerID);
			if (entity == null)
			{
				this.Context.Set<Customer>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int customerID)
		{
			Customer record = await this.GetById(customerID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Customer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_Customer_AccountNumber.
		public async virtual Task<Customer> ByAccountNumber(string accountNumber)
		{
			return await this.Context.Set<Customer>().FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);
		}

		// unique constraint AK_Customer_rowguid.
		public async virtual Task<Customer> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Customer>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Non-unique constraint IX_Customer_TerritoryID.
		public async virtual Task<List<Customer>> ByTerritoryID(int? territoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.TerritoryID == territoryID, limit, offset);
		}

		// Foreign key reference to this table SalesOrderHeader via customerID.
		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>().Where(x => x.CustomerID == customerID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		// Foreign key reference to table Store via storeID.
		public async virtual Task<Store> StoreByStoreID(int? storeID)
		{
			return await this.Context.Set<Store>().SingleOrDefaultAsync(x => x.BusinessEntityID == storeID);
		}

		// Foreign key reference to table SalesTerritory via territoryID.
		public async virtual Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID)
		{
			return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.TerritoryID == territoryID);
		}

		protected async Task<List<Customer>> Where(
			Expression<Func<Customer, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Customer, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CustomerID;
			}

			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Customer>();
		}

		private async Task<Customer> GetById(int customerID)
		{
			List<Customer> records = await this.Where(x => x.CustomerID == customerID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3e84c0eea4b9436215a7a76d0bbbea53</Hash>
</Codenesium>*/