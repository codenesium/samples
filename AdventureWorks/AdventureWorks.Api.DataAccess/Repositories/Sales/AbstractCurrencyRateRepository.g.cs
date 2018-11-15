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
	public abstract class AbstractCurrencyRateRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCurrencyRateRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CurrencyRate>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<CurrencyRate> Get(int currencyRateID)
		{
			return await this.GetById(currencyRateID);
		}

		public async virtual Task<CurrencyRate> Create(CurrencyRate item)
		{
			this.Context.Set<CurrencyRate>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CurrencyRate item)
		{
			var entity = this.Context.Set<CurrencyRate>().Local.FirstOrDefault(x => x.CurrencyRateID == item.CurrencyRateID);
			if (entity == null)
			{
				this.Context.Set<CurrencyRate>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int currencyRateID)
		{
			CurrencyRate record = await this.GetById(currencyRateID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CurrencyRate>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<CurrencyRate> ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate, string fromCurrencyCode, string toCurrencyCode)
		{
			return await this.Context.Set<CurrencyRate>().SingleOrDefaultAsync(x => x.CurrencyRateDate == currencyRateDate && x.FromCurrencyCode == fromCurrencyCode && x.ToCurrencyCode == toCurrencyCode);
		}

		public async virtual Task<List<SalesOrderHeader>> SalesOrderHeadersByCurrencyRateID(int currencyRateID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SalesOrderHeader>().Where(x => x.CurrencyRateID == currencyRateID).AsQueryable().Skip(offset).Take(limit).ToListAsync<SalesOrderHeader>();
		}

		public async virtual Task<Currency> CurrencyByFromCurrencyCode(string fromCurrencyCode)
		{
			return await this.Context.Set<Currency>().SingleOrDefaultAsync(x => x.CurrencyCode == fromCurrencyCode);
		}

		public async virtual Task<Currency> CurrencyByToCurrencyCode(string toCurrencyCode)
		{
			return await this.Context.Set<Currency>().SingleOrDefaultAsync(x => x.CurrencyCode == toCurrencyCode);
		}

		protected async Task<List<CurrencyRate>> Where(
			Expression<Func<CurrencyRate, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CurrencyRate, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CurrencyRateID;
			}

			return await this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
		}

		private async Task<CurrencyRate> GetById(int currencyRateID)
		{
			List<CurrencyRate> records = await this.Where(x => x.CurrencyRateID == currencyRateID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e8c2636a359186ccd05f0851bf95699d</Hash>
</Codenesium>*/