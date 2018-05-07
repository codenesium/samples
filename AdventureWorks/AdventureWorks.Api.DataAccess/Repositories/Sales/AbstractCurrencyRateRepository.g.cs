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

		public virtual int Create(
			CurrencyRateModel model)
		{
			EFCurrencyRate record = new EFCurrencyRate();

			this.Mapper.CurrencyRateMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFCurrencyRate>().Add(record);
			this.Context.SaveChanges();
			return record.CurrencyRateID;
		}

		public virtual void Update(
			int currencyRateID,
			CurrencyRateModel model)
		{
			EFCurrencyRate record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
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
			EFCurrencyRate record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCurrencyRate>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOCurrencyRate Get(int currencyRateID)
		{
			return this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
		}

		public virtual List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOCurrencyRate> Where(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCurrencyRate> SearchLinqPOCO(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCurrencyRate> response = new List<POCOCurrencyRate>();
			List<EFCurrencyRate> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CurrencyRateMapEFToPOCO(x)));
			return response;
		}

		private List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("CurrencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this.Context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}

		private List<EFCurrencyRate> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy("CurrencyRateID ASC").Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
			else
			{
				return this.Context.Set<EFCurrencyRate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCurrencyRate>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>dfbd2de76a113c3d882f90f5e4ecdf29</Hash>
</Codenesium>*/