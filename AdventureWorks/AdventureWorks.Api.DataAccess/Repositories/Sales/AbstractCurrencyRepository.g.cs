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
	public abstract class AbstractCurrencyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractCurrencyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Currency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<Currency> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<Currency>> Where(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<Currency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<Currency>> SearchLinqEF(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}
			return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Currency>();
		}

		private async Task<List<Currency>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Currency.CurrencyCode)} ASC";
			}

			return await this.Context.Set<Currency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Currency>();
		}

		private async Task<Currency> GetById(string currencyCode)
		{
			List<Currency> records = await this.SearchLinqEF(x => x.CurrencyCode == currencyCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4fbaf5c9af7371a9e6dbd2ccda5ccfc5</Hash>
</Codenesium>*/