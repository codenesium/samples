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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCurrencyRateRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCurrencyRate Get(int currencyRateID)
		{
			return this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
		}

		public virtual POCOCurrencyRate Create(
			ApiCurrencyRateModel model)
		{
			CurrencyRate record = new CurrencyRate();

			this.Mapper.CurrencyRateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CurrencyRate>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CurrencyRateMapEFToPOCO(record);
		}

		public virtual void Update(
			int currencyRateID,
			ApiCurrencyRateModel model)
		{
			CurrencyRate record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{currencyRateID}");
			}
			else
			{
				this.Mapper.CurrencyRateMapModelToEF(
					currencyRateID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int currencyRateID)
		{
			CurrencyRate record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CurrencyRate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCurrencyRate GetCurrencyRateDateFromCurrencyCodeToCurrencyCode(DateTime currencyRateDate,string fromCurrencyCode,string toCurrencyCode)
		{
			return this.SearchLinqPOCO(x => x.CurrencyRateDate == currencyRateDate && x.FromCurrencyCode == fromCurrencyCode && x.ToCurrencyCode == toCurrencyCode).FirstOrDefault();
		}

		protected List<POCOCurrencyRate> Where(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCurrencyRate> SearchLinqPOCO(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrencyRate> response = new List<POCOCurrencyRate>();
			List<CurrencyRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CurrencyRateMapEFToPOCO(x)));
			return response;
		}

		private List<CurrencyRate> SearchLinqEF(Expression<Func<CurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
			}
			return this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CurrencyRate>();
		}

		private List<CurrencyRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CurrencyRate.CurrencyRateID)} ASC";
			}

			return this.Context.Set<CurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CurrencyRate>();
		}
	}
}

/*<Codenesium>
    <Hash>a2dea5aaa33484f9eaf6f8e67e3e685d</Hash>
</Codenesium>*/