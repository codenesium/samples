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
	public abstract class AbstractSalesTaxRateRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractSalesTaxRateRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SalesTaxRate>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<SalesTaxRate> Get(int salesTaxRateID)
		{
			return await this.GetById(salesTaxRateID);
		}

		public async virtual Task<SalesTaxRate> Create(SalesTaxRate item)
		{
			this.Context.Set<SalesTaxRate>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SalesTaxRate item)
		{
			var entity = this.Context.Set<SalesTaxRate>().Local.FirstOrDefault(x => x.SalesTaxRateID == item.SalesTaxRateID);
			if (entity == null)
			{
				this.Context.Set<SalesTaxRate>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int salesTaxRateID)
		{
			SalesTaxRate record = await this.GetById(salesTaxRateID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTaxRate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_SalesTaxRate_rowguid.
		public async virtual Task<SalesTaxRate> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<SalesTaxRate>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// unique constraint AK_SalesTaxRate_StateProvinceID_TaxType.
		public async virtual Task<SalesTaxRate> ByStateProvinceIDTaxType(int stateProvinceID, int taxType)
		{
			return await this.Context.Set<SalesTaxRate>().FirstOrDefaultAsync(x => x.StateProvinceID == stateProvinceID && x.TaxType == taxType);
		}

		protected async Task<List<SalesTaxRate>> Where(
			Expression<Func<SalesTaxRate, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<SalesTaxRate, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.SalesTaxRateID;
			}

			return await this.Context.Set<SalesTaxRate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SalesTaxRate>();
		}

		private async Task<SalesTaxRate> GetById(int salesTaxRateID)
		{
			List<SalesTaxRate> records = await this.Where(x => x.SalesTaxRateID == salesTaxRateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>dca6f9a90d14517c71281958042a4a97</Hash>
</Codenesium>*/