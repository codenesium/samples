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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCurrencyRateRepository(ILogger logger,
		                                      ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime currencyRateDate,
		                          string fromCurrencyCode,
		                          string toCurrencyCode,
		                          decimal averageRate,
		                          decimal endOfDayRate,
		                          DateTime modifiedDate)
		{
			var record = new EFCurrencyRate ();

			MapPOCOToEF(0, currencyRateDate,
			            fromCurrencyCode,
			            toCurrencyCode,
			            averageRate,
			            endOfDayRate,
			            modifiedDate, record);

			this._context.Set<EFCurrencyRate>().Add(record);
			this._context.SaveChanges();
			return record.CurrencyRateID;
		}

		public virtual void Update(int currencyRateID, DateTime currencyRateDate,
		                           string fromCurrencyCode,
		                           string toCurrencyCode,
		                           decimal averageRate,
		                           decimal endOfDayRate,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",currencyRateID);
			}
			else
			{
				MapPOCOToEF(currencyRateID,  currencyRateDate,
				            fromCurrencyCode,
				            toCurrencyCode,
				            averageRate,
				            endOfDayRate,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int currencyRateID)
		{
			var record = this.SearchLinqEF(x => x.CurrencyRateID == currencyRateID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFCurrencyRate>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int currencyRateID, Response response)
		{
			this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID,response);
		}

		protected virtual List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrencyRate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFCurrencyRate, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCurrencyRate> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCurrencyRate> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int currencyRateID, DateTime currencyRateDate,
		                               string fromCurrencyCode,
		                               string toCurrencyCode,
		                               decimal averageRate,
		                               decimal endOfDayRate,
		                               DateTime modifiedDate, EFCurrencyRate   efCurrencyRate)
		{
			efCurrencyRate.CurrencyRateID = currencyRateID;
			efCurrencyRate.CurrencyRateDate = currencyRateDate;
			efCurrencyRate.FromCurrencyCode = fromCurrencyCode;
			efCurrencyRate.ToCurrencyCode = toCurrencyCode;
			efCurrencyRate.AverageRate = averageRate;
			efCurrencyRate.EndOfDayRate = endOfDayRate;
			efCurrencyRate.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCurrencyRate efCurrencyRate,Response response)
		{
			if(efCurrencyRate == null)
			{
				return;
			}
			response.AddCurrencyRate(new POCOCurrencyRate()
			{
				CurrencyRateID = efCurrencyRate.CurrencyRateID.ToInt(),
				CurrencyRateDate = efCurrencyRate.CurrencyRateDate.ToDateTime(),
				AverageRate = efCurrencyRate.AverageRate,
				EndOfDayRate = efCurrencyRate.EndOfDayRate,
				ModifiedDate = efCurrencyRate.ModifiedDate.ToDateTime(),

				FromCurrencyCode = new ReferenceEntity<string>(efCurrencyRate.FromCurrencyCode,
				                                               "Currencies"),
				ToCurrencyCode = new ReferenceEntity<string>(efCurrencyRate.ToCurrencyCode,
				                                             "Currencies"),
			});

			CurrencyRepository.MapEFToPOCO(efCurrencyRate.CurrencyRef, response);

			CurrencyRepository.MapEFToPOCO(efCurrencyRate.CurrencyRef1, response);
		}
	}
}

/*<Codenesium>
    <Hash>9a7ef21319bfdf7a4e9220bc2c017e0b</Hash>
</Codenesium>*/