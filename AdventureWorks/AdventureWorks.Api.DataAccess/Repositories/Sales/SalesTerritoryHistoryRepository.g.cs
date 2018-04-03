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
	public abstract class AbstractSalesTerritoryHistoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesTerritoryHistoryRepository(ILogger logger,
		                                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(int territoryID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesTerritoryHistory ();

			MapPOCOToEF(0, territoryID,
			            startDate,
			            endDate,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesTerritoryHistory>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, int territoryID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
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
				            startDate,
				            endDate,
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
				this._context.Set<EFSalesTerritoryHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEF(Expression<Func<EFSalesTerritoryHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTerritoryHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTerritoryHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTerritoryHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, int territoryID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesTerritoryHistory   efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.businessEntityID = businessEntityID;
			efSalesTerritoryHistory.territoryID = territoryID;
			efSalesTerritoryHistory.startDate = startDate;
			efSalesTerritoryHistory.endDate = endDate;
			efSalesTerritoryHistory.rowguid = rowguid;
			efSalesTerritoryHistory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTerritoryHistory efSalesTerritoryHistory,Response response)
		{
			if(efSalesTerritoryHistory == null)
			{
				return;
			}
			response.AddSalesTerritoryHistory(new POCOSalesTerritoryHistory()
			{
				BusinessEntityID = efSalesTerritoryHistory.businessEntityID.ToInt(),
				TerritoryID = efSalesTerritoryHistory.territoryID.ToInt(),
				StartDate = efSalesTerritoryHistory.startDate.ToDateTime(),
				EndDate = efSalesTerritoryHistory.endDate.ToNullableDateTime(),
				Rowguid = efSalesTerritoryHistory.rowguid,
				ModifiedDate = efSalesTerritoryHistory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>f7664293ce8437d34b10163123f56026</Hash>
</Codenesium>*/