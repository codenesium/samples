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
	public abstract class AbstractCurrencyRateRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCurrencyRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			CurrencyRateModel model)
		{
			var record = new EFCurrencyRate();

			this.mapper.CurrencyRateMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFCurrencyRate>().Add(record);
			this.context.SaveChanges();
			return record.CurrencyRateID;
		}

		public virtual void Update(
			int currencyRateID,
			CurrencyRateModel model)
		{
			var record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{currencyRateID}");
			}
			else
			{
				this.mapper.CurrencyRateMapModelToEF(
					currencyRateID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int currencyRateID)
		{
			var record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCurrencyRate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int currencyRateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID, response);
			return response;
		}

		public virtual POCOCurrencyRate GetByIdDirect(int currencyRateID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID, response);
			return response.CurrencyRates.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CurrencyRates;
		}

		private void SearchLinqPOCO(Expression<Func<EFCurrencyRate, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCurrencyRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CurrencyRateMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCurrencyRate> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CurrencyRateMapEFToPOCO(x, response));
		}

		protected virtual List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrencyRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>836d1dc29d158afbe19134ba43a18902</Hash>
</Codenesium>*/