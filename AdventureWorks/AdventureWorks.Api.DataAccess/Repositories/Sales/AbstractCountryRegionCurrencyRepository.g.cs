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
	public abstract class AbstractCountryRegionCurrencyRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRegionCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCountryRegionCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCountryRegionCurrency> Get(string countryRegionCode)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			return this.Mapper.CountryRegionCurrencyMapEFToPOCO(record);
		}

		public async virtual Task<POCOCountryRegionCurrency> Create(
			ApiCountryRegionCurrencyModel model)
		{
			CountryRegionCurrency record = new CountryRegionCurrency();

			this.Mapper.CountryRegionCurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<CountryRegionCurrency>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CountryRegionCurrencyMapEFToPOCO(record);
		}

		public async virtual Task Update(
			string countryRegionCode,
			ApiCountryRegionCurrencyModel model)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.Mapper.CountryRegionCurrencyMapModelToEF(
					countryRegionCode,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string countryRegionCode)
		{
			CountryRegionCurrency record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegionCurrency>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOCountryRegionCurrency>> GetCurrencyCode(string currencyCode)
		{
			var records = await this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode);

			return records;
		}

		protected async Task<List<POCOCountryRegionCurrency>> Where(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegionCurrency> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCountryRegionCurrency>> SearchLinqPOCO(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegionCurrency> response = new List<POCOCountryRegionCurrency>();
			List<CountryRegionCurrency> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CountryRegionCurrencyMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<CountryRegionCurrency>> SearchLinqEF(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}
			return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
		}

		private async Task<List<CountryRegionCurrency>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}

			return await this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegionCurrency>();
		}

		private async Task<CountryRegionCurrency> GetById(string countryRegionCode)
		{
			List<CountryRegionCurrency> records = await this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>095261300d54089e5d0b277ec11c0f68</Hash>
</Codenesium>*/