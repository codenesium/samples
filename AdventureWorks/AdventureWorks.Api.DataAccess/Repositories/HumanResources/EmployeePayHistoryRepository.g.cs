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
	public abstract class AbstractEmployeePayHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractEmployeePayHistoryRepository(ILogger logger,
		                                            ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime rateChangeDate,
		                          decimal rate,
		                          int payFrequency,
		                          DateTime modifiedDate)
		{
			var record = new EFEmployeePayHistory ();

			MapPOCOToEF(0, rateChangeDate,
			            rate,
			            payFrequency,
			            modifiedDate, record);

			this._context.Set<EFEmployeePayHistory>().Add(record);
			this._context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, DateTime rateChangeDate,
		                           decimal rate,
		                           int payFrequency,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  rateChangeDate,
				            rate,
				            payFrequency,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFEmployeePayHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFEmployeePayHistory> SearchLinqEF(Expression<Func<EFEmployeePayHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployeePayHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFEmployeePayHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployeePayHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployeePayHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployeePayHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, DateTime rateChangeDate,
		                               decimal rate,
		                               int payFrequency,
		                               DateTime modifiedDate, EFEmployeePayHistory   efEmployeePayHistory)
		{
			efEmployeePayHistory.BusinessEntityID = businessEntityID;
			efEmployeePayHistory.RateChangeDate = rateChangeDate;
			efEmployeePayHistory.Rate = rate;
			efEmployeePayHistory.PayFrequency = payFrequency;
			efEmployeePayHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmployeePayHistory efEmployeePayHistory,Response response)
		{
			if(efEmployeePayHistory == null)
			{
				return;
			}
			response.AddEmployeePayHistory(new POCOEmployeePayHistory()
			{
				RateChangeDate = efEmployeePayHistory.RateChangeDate.ToDateTime(),
				Rate = efEmployeePayHistory.Rate,
				PayFrequency = efEmployeePayHistory.PayFrequency,
				ModifiedDate = efEmployeePayHistory.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efEmployeePayHistory.BusinessEntityID,
				                                            "Employees"),
			});

			EmployeeRepository.MapEFToPOCO(efEmployeePayHistory.EmployeeRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>470ceae1f0d0f8fd33954b26faf89547</Hash>
</Codenesium>*/