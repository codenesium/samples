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

		public AbstractCurrencyRateRepository(ILogger logger,
		                                      ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFCurrencyRate>().Add(record);
			this.context.SaveChanges();
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
				this.logger.LogError("Unable to find id:{0}",currencyRateID);
			}
			else
			{
				MapPOCOToEF(currencyRateID,  currencyRateDate,
				            fromCurrencyCode,
				            toCurrencyCode,
				            averageRate,
				            endOfDayRate,
				            modifiedDate, record);
				this.context.SaveChanges();
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
				this.context.Set<EFCurrencyRate>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int currencyRateID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID,response);
			return response;
		}

		public virtual POCOCurrencyRate GetByIdDirect(int currencyRateID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CurrencyRateID == currencyRateID,response);
			return response.CurrencyRates.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CurrencyRates;
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

		protected virtual List<EFCurrencyRate> SearchLinqEF(Expression<Func<EFCurrencyRate, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCurrencyRate> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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

			CurrencyRepository.MapEFToPOCO(efCurrencyRate.Currency, response);

			CurrencyRepository.MapEFToPOCO(efCurrencyRate.Currency1, response);
		}
	}
}

/*<Codenesium>
    <Hash>fe501757cf7d45734d196ccfb0d8cd40</Hash>
</Codenesium>*/