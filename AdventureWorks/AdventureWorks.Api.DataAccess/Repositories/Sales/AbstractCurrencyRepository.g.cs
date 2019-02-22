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
	public abstract class AbstractCurrencyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCurrencyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Currency>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.CurrencyCode.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Currency> Get(string currencyCode)
		{
			return await this.GetById(currencyCode);
		}

		public async virtual Task<Currency> Create(Currency item)
		{
			this.Context.Set<Currency>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Currency item)
		{
			var entity = this.Context.Set<Currency>().Local.FirstOrDefault(x => x.CurrencyCode == item.CurrencyCode);
			if (entity == null)
			{
				this.Context.Set<Currency>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string currencyCode)
		{
			Currency record = await this.GetById(currencyCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Currency>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_Currency_Name.
		public async virtual Task<Currency> ByName(string name)
		{
			return await this.Context.Set<Currency>()

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// Foreign key reference to this table CurrencyRate via fromCurrencyCode.
		public async virtual Task<List<CurrencyRate>> CurrencyRatesByFromCurrencyCode(string fromCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CurrencyRate>()
			       .Include(x => x.FromCurrencyCodeNavigation)
			       .Where(x => x.FromCurrencyCode == fromCurrencyCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
		}

		// Foreign key reference to this table CurrencyRate via toCurrencyCode.
		public async virtual Task<List<CurrencyRate>> CurrencyRatesByToCurrencyCode(string toCurrencyCode, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CurrencyRate>()
			       .Include(x => x.ToCurrencyCodeNavigation)
			       .Where(x => x.ToCurrencyCode == toCurrencyCode).AsQueryable().Skip(offset).Take(limit).ToListAsync<CurrencyRate>();
		}

		protected async Task<List<Currency>> Where(
			Expression<Func<Currency, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Currency, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CurrencyCode;
			}

			return await this.Context.Set<Currency>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Currency>();
		}

		private async Task<Currency> GetById(string currencyCode)
		{
			List<Currency> records = await this.Where(x => x.CurrencyCode == currencyCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a8a0b131af4266d8f06982a40150cd5e</Hash>
</Codenesium>*/