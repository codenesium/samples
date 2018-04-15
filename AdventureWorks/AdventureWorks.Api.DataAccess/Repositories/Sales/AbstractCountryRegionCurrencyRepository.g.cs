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
		protected IObjectMapper mapper;

		public AbstractCountryRegionCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			CountryRegionCurrencyModel model)
		{
			var record = new EFCountryRegionCurrency();

			this.mapper.CountryRegionCurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.context.Set<EFCountryRegionCurrency>().Add(record);
			this.context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(
			string countryRegionCode,
			CountryRegionCurrencyModel model)
		{
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.mapper.CountryRegionCurrencyMapModelToEF(
					countryRegionCode,
					model,
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

		public virtual ApiResponse GetById(string countryRegionCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response;
		}

		public virtual POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response.CountryRegionCurrencies.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CountryRegionCurrencies;
		}

		private void SearchLinqPOCO(Expression<Func<EFCountryRegionCurrency, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegionCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CountryRegionCurrencyMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegionCurrency> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CountryRegionCurrencyMapEFToPOCO(x, response));
		}

		protected virtual List<EFCountryRegionCurrency> SearchLinqEF(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCountryRegionCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>134407f2ef47ac99081a4ea6d8f176da</Hash>
</Codenesium>*/