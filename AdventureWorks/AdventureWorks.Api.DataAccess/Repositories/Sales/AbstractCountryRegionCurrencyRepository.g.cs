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

		public virtual string Create(
			CountryRegionCurrencyModel model)
		{
			EFCountryRegionCurrency record = new EFCountryRegionCurrency();

			this.Mapper.CountryRegionCurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFCountryRegionCurrency>().Add(record);
			this.Context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(
			string countryRegionCode,
			CountryRegionCurrencyModel model)
		{
			EFCountryRegionCurrency record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
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
			EFCountryRegionCurrency record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCountryRegionCurrency>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode);
		}

		public virtual POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode).CountryRegionCurrencies.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).CountryRegionCurrencies;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCountryRegionCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CountryRegionCurrencyMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCountryRegionCurrency> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CountryRegionCurrencyMapEFToPOCO(x, response));
			return response;
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
    <Hash>009f5bd1930d34e9a4b39fdf162a9c99</Hash>
</Codenesium>*/