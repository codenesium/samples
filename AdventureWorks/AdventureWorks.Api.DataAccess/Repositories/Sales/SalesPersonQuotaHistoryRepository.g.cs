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
	public abstract class AbstractSalesPersonQuotaHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesPersonQuotaHistoryRepository(ILogger logger,
		                                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(DateTime quotaDate,
		                          decimal salesQuota,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesPersonQuotaHistory ();

			MapPOCOToEF(0, quotaDate,
			            salesQuota,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesPersonQuotaHistory>().Add(record);
			this._context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, DateTime quotaDate,
		                           decimal salesQuota,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  quotaDate,
				            salesQuota,
				            rowguid,
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
				this._context.Set<EFSalesPersonQuotaHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, DateTime quotaDate,
		                               decimal salesQuota,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesPersonQuotaHistory   efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.BusinessEntityID = businessEntityID;
			efSalesPersonQuotaHistory.QuotaDate = quotaDate;
			efSalesPersonQuotaHistory.SalesQuota = salesQuota;
			efSalesPersonQuotaHistory.rowguid = rowguid;
			efSalesPersonQuotaHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesPersonQuotaHistory efSalesPersonQuotaHistory,Response response)
		{
			if(efSalesPersonQuotaHistory == null)
			{
				return;
			}
			response.AddSalesPersonQuotaHistory(new POCOSalesPersonQuotaHistory()
			{
				QuotaDate = efSalesPersonQuotaHistory.QuotaDate.ToDateTime(),
				SalesQuota = efSalesPersonQuotaHistory.SalesQuota,
				Rowguid = efSalesPersonQuotaHistory.rowguid,
				ModifiedDate = efSalesPersonQuotaHistory.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efSalesPersonQuotaHistory.BusinessEntityID,
				                                            "SalesPersons"),
			});

			SalesPersonRepository.MapEFToPOCO(efSalesPersonQuotaHistory.SalesPersonRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>8a61ea75e739509b32c1c97464b21438</Hash>
</Codenesium>*/