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
	public abstract class AbstractSalesPersonRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesPersonRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Nullable<int> territoryID,
		                          Nullable<decimal> salesQuota,
		                          decimal bonus,
		                          decimal commissionPct,
		                          decimal salesYTD,
		                          decimal salesLastYear,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesPerson ();

			MapPOCOToEF(0, territoryID,
			            salesQuota,
			            bonus,
			            commissionPct,
			            salesYTD,
			            salesLastYear,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesPerson>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, Nullable<int> territoryID,
		                           Nullable<decimal> salesQuota,
		                           decimal bonus,
		                           decimal commissionPct,
		                           decimal salesYTD,
		                           decimal salesLastYear,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  territoryID,
				            salesQuota,
				            bonus,
				            commissionPct,
				            salesYTD,
				            salesLastYear,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesPerson>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFSalesPerson> SearchLinqEF(Expression<Func<EFSalesPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPerson, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPerson> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesPerson> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, Nullable<int> territoryID,
		                               Nullable<decimal> salesQuota,
		                               decimal bonus,
		                               decimal commissionPct,
		                               decimal salesYTD,
		                               decimal salesLastYear,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesPerson   efSalesPerson)
		{
			efSalesPerson.businessEntityID = businessEntityID;
			efSalesPerson.territoryID = territoryID;
			efSalesPerson.salesQuota = salesQuota;
			efSalesPerson.bonus = bonus;
			efSalesPerson.commissionPct = commissionPct;
			efSalesPerson.salesYTD = salesYTD;
			efSalesPerson.salesLastYear = salesLastYear;
			efSalesPerson.rowguid = rowguid;
			efSalesPerson.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesPerson efSalesPerson,Response response)
		{
			if(efSalesPerson == null)
			{
				return;
			}
			response.AddSalesPerson(new POCOSalesPerson()
			{
				BusinessEntityID = efSalesPerson.businessEntityID.ToInt(),
				TerritoryID = efSalesPerson.territoryID.ToNullableInt(),
				SalesQuota = efSalesPerson.salesQuota,
				Bonus = efSalesPerson.bonus,
				CommissionPct = efSalesPerson.commissionPct,
				SalesYTD = efSalesPerson.salesYTD,
				SalesLastYear = efSalesPerson.salesLastYear,
				Rowguid = efSalesPerson.rowguid,
				ModifiedDate = efSalesPerson.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>655468f4f589eafcba601fb216f65492</Hash>
</Codenesium>*/