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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesPersonQuotaHistoryRepository(ILogger logger,
		                                                 ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFSalesPersonQuotaHistory>().Add(record);
			this.context.SaveChanges();
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
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  quotaDate,
				            salesQuota,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
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
				this.context.Set<EFSalesPersonQuotaHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.SalesPersonQuotaHistories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesPersonQuotaHistories;
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

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, DateTime quotaDate,
		                               decimal salesQuota,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesPersonQuotaHistory   efSalesPersonQuotaHistory)
		{
			efSalesPersonQuotaHistory.BusinessEntityID = businessEntityID;
			efSalesPersonQuotaHistory.QuotaDate = quotaDate;
			efSalesPersonQuotaHistory.SalesQuota = salesQuota;
			efSalesPersonQuotaHistory.Rowguid = rowguid;
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
				Rowguid = efSalesPersonQuotaHistory.Rowguid,
				ModifiedDate = efSalesPersonQuotaHistory.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efSalesPersonQuotaHistory.BusinessEntityID,
				                                            "SalesPersons"),
			});

			SalesPersonRepository.MapEFToPOCO(efSalesPersonQuotaHistory.SalesPerson, response);
		}
	}
}

/*<Codenesium>
    <Hash>49b6ff7cacbcdcb2e5139cc0f0df8cbc</Hash>
</Codenesium>*/