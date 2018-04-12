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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractCountryRegionCurrencyRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			string currencyCode,
			DateTime modifiedDate)
		{
			var record = new EFCountryRegionCurrency();

			MapPOCOToEF(
				string.Empty,
				currencyCode,
				modifiedDate,
				record);

			this.context.Set<EFCountryRegionCurrency>().Add(record);
			this.context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				MapPOCOToEF(
					countryRegionCode,
					currencyCode,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			string countryRegionCode)
		{
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCountryRegionCurrency>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(string countryRegionCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response;
		}

		public virtual POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response.CountryRegionCurrencies.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CountryRegionCurrencies;
		}

		private void SearchLinqPOCO(Expression<Func<EFCountryRegionCurrency, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegionCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegionCurrency> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFCountryRegionCurrency> SearchLinqEF(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCountryRegionCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate,
			EFCountryRegionCurrency efCountryRegionCurrency)
		{
			efCountryRegionCurrency.SetProperties(countryRegionCode, currencyCode, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFCountryRegionCurrency efCountryRegionCurrency,
			Response response)
		{
			if (efCountryRegionCurrency == null)
			{
				return;
			}

			response.AddCountryRegionCurrency(new POCOCountryRegionCurrency(efCountryRegionCurrency.CountryRegionCode, efCountryRegionCurrency.CurrencyCode, efCountryRegionCurrency.ModifiedDate.ToDateTime()));

			CountryRegionRepository.MapEFToPOCO(efCountryRegionCurrency.CountryRegion, response);

			CurrencyRepository.MapEFToPOCO(efCountryRegionCurrency.Currency, response);
		}
	}
}

/*<Codenesium>
    <Hash>a47540856571e1da2215ac4432440b11</Hash>
</Codenesium>*/