using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCountryRegionCurrencyRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRegionCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCountryRegionCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCountryRegionCurrency Get(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
		}

		public virtual POCOCountryRegionCurrency Create(
			ApiCountryRegionCurrencyModel model)
		{
			CountryRegionCurrency record = new CountryRegionCurrency();

			this.Mapper.CountryRegionCurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<CountryRegionCurrency>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CountryRegionCurrencyMapEFToPOCO(record);
		}

		public virtual void Update(
			string countryRegionCode,
			ApiCountryRegionCurrencyModel model)
		{
			CountryRegionCurrency record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string countryRegionCode)
		{
			CountryRegionCurrency record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegionCurrency>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOCountryRegionCurrency> GetCurrencyCode(string currencyCode)
		{
			return this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode);
		}

		protected List<POCOCountryRegionCurrency> Where(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCountryRegionCurrency> SearchLinqPOCO(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegionCurrency> response = new List<POCOCountryRegionCurrency>();
			List<CountryRegionCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CountryRegionCurrencyMapEFToPOCO(x)));
			return response;
		}

		private List<CountryRegionCurrency> SearchLinqEF(Expression<Func<CountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}
			return this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRegionCurrency>();
		}

		private List<CountryRegionCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegionCurrency.CountryRegionCode)} ASC";
			}

			return this.Context.Set<CountryRegionCurrency>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRegionCurrency>();
		}
	}
}

/*<Codenesium>
    <Hash>871fc703f1dc4acae66b265f0ea93484</Hash>
</Codenesium>*/