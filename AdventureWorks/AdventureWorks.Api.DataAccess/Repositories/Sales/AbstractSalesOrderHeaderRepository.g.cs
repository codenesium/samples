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
	public abstract class AbstractSalesOrderHeaderRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesOrderHeaderRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesOrderHeader>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesOrderHeader> Get(int salesOrderID)
		{
			return await this.GetById(salesOrderID);
		}

		public async virtual Task<SalesOrderHeader> Create(SalesOrderHeader item)
		{
			this.Context.Set<SalesOrderHeader>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesOrderHeader item)
		{
			var entity = this.Context.Set<SalesOrderHeader>().Local.FirstOrDefault(x => x.SalesOrderID == item.SalesOrderID);
			if (entity == null)
			{
				this.Context.Set<SalesOrderHeader>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int salesOrderID)
		{
			SalesOrderHeader record = await this.GetById(salesOrderID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesOrderHeader>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_SalesOrderHeader_rowguid.
		public async virtual Task<SalesOrderHeader> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<SalesOrderHeader>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// unique constraint AK_SalesOrderHeader_SalesOrderNumber.
		public async virtual Task<SalesOrderHeader> BySalesOrderNumber(string salesOrderNumber)
		{
			return await this.Context.Set<SalesOrderHeader>().FirstOrDefaultAsync(x => x.SalesOrderNumber == salesOrderNumber);
		}

		// Non-unique constraint IX_SalesOrderHeader_CustomerID.
		public async virtual Task<List<SalesOrderHeader>> ByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CustomerID == customerID, limit, offset);
		}

		// Non-unique constraint IX_SalesOrderHeader_SalesPersonID.
		public async virtual Task<List<SalesOrderHeader>> BySalesPersonID(int? salesPersonID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.SalesPersonID == salesPersonID, limit, offset);
		}

		// Foreign key reference to table CreditCard via creditCardID.
		public async virtual Task<CreditCard> CreditCardByCreditCardID(int? creditCardID)
		{
			return await this.Context.Set<CreditCard>().SingleOrDefaultAsync(x => x.CreditCardID == creditCardID);
		}

		// Foreign key reference to table CurrencyRate via currencyRateID.
		public async virtual Task<CurrencyRate> CurrencyRateByCurrencyRateID(int? currencyRateID)
		{
			return await this.Context.Set<CurrencyRate>().SingleOrDefaultAsync(x => x.CurrencyRateID == currencyRateID);
		}

		// Foreign key reference to table Customer via customerID.
		public async virtual Task<Customer> CustomerByCustomerID(int customerID)
		{
			return await this.Context.Set<Customer>().SingleOrDefaultAsync(x => x.CustomerID == customerID);
		}

		// Foreign key reference to table SalesPerson via salesPersonID.
		public async virtual Task<SalesPerson> SalesPersonBySalesPersonID(int? salesPersonID)
		{
			return await this.Context.Set<SalesPerson>().SingleOrDefaultAsync(x => x.BusinessEntityID == salesPersonID);
		}

		// Foreign key reference to table SalesTerritory via territoryID.
		public async virtual Task<SalesTerritory> SalesTerritoryByTerritoryID(int? territoryID)
		{
			return await this.Context.Set<SalesTerritory>().SingleOrDefaultAsync(x => x.TerritoryID == territoryID);
		}

		protected async Task<List<SalesOrderHeader>> Where(
			Expression<Func<SalesOrderHeader, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesOrderHeader, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SalesOrderID;
			}

			return await this.Context.Set<SalesOrderHeader>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		private async Task<SalesOrderHeader> GetById(int salesOrderID)
		{
			List<SalesOrderHeader> records = await this.Where(x => x.SalesOrderID == salesOrderID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>90452164736622b0f5f069e605ea8eaa</Hash>
</Codenesium>*/