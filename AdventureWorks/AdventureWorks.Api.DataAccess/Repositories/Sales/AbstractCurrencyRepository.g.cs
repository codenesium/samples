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
	public abstract class AbstractCurrencyRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual string Create(
			CurrencyModel model)
		{
			EFCurrency record = new EFCurrency();

			this.Mapper.CurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFCurrency>().Add(record);
			this.Context.SaveChanges();
			return record.CurrencyCode;
		}

		public virtual void Update(
			string currencyCode,
			CurrencyModel model)
		{
			EFCurrency record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string currencyCode)
		{
			EFCurrency record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCurrency>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string currencyCode)
		{
			return this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode);
		}

		public virtual POCOCurrency GetByIdDirect(string currencyCode)
		{
			return this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode).Currencies.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Currencies;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CurrencyMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCurrency> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CurrencyMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFCurrency> SearchLinqEF(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrency> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>4cc1ddec88d5b57d8c418ba8e3af5c5e</Hash>
</Codenesium>*/