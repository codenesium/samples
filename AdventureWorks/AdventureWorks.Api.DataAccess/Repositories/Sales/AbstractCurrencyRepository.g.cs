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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCurrencyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			CurrencyModel model)
		{
			var record = new EFCurrency();

			this.mapper.CurrencyMapModelToEF(
				default (string),
				model,
				record);

			this.context.Set<EFCurrency>().Add(record);
			this.context.SaveChanges();
			return record.CurrencyCode;
		}

		public virtual void Update(
			string currencyCode,
			CurrencyModel model)
		{
			var record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{currencyCode}");
			}
			else
			{
				this.mapper.CurrencyMapModelToEF(
					currencyCode,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			string currencyCode)
		{
			var record = this.SearchLinqEF(x => x.CurrencyCode == currencyCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCurrency>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string currencyCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode, response);
			return response;
		}

		public virtual POCOCurrency GetByIdDirect(string currencyCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CurrencyCode == currencyCode, response);
			return response.Currencies.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Currencies;
		}

		private void SearchLinqPOCO(Expression<Func<EFCurrency, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCurrency> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CurrencyMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCurrency> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CurrencyMapEFToPOCO(x, response));
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
    <Hash>44f5d22e8cbabb196d55b32a844457f3</Hash>
</Codenesium>*/