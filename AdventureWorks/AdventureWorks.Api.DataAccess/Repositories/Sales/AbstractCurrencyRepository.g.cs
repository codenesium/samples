using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCurrencyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCurrency> Get(string currencyCode)
		{
			Currency record = await this.GetById(currencyCode);

			return this.Mapper.CurrencyMapEFToPOCO(record);
		}

		public async virtual Task<POCOCurrency> Create(
			ApiCurrencyModel model)
		{
			Currency record = new Currency();

			this.Mapper.CurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<Currency>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CurrencyMapEFToPOCO(record);
		}

		public async virtual Task Update(
			string currencyCode,
			ApiCurrencyModel model)
		{
			Currency record = await this.GetById(currencyCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyCode}");
			}
			else
			{
				this.Mapper.CurrencyMapModelToEF(
					currencyCode,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		public async Task<POCOCurrency> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOCurrency>> Where(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrency> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCurrency>> SearchLinqPOCO(Expression<Func<Currency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrency> response = new List<POCOCurrency>();
			List<Currency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CurrencyMapEFToPOCO(x)));
			return response;
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
    <Hash>1010f5694f21b75e0e266d2308f5f3a3</Hash>
</Codenesium>*/