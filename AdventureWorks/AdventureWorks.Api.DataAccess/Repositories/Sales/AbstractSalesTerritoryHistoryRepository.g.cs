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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesTerritoryHistoryRepository(ILogger logger,
		                                               ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFSalesTerritoryHistory>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, int territoryID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
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
				MapPOCOToEF(businessEntityID,  territoryID,
				            startDate,
				            endDate,
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
				this.context.Set<EFSalesTerritoryHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOSalesTerritoryHistory GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.SalesTerritoryHistories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesTerritoryHistory> GetWhereDirect(Expression<Func<EFSalesTerritoryHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesTerritoryHistories;
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

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEF(Expression<Func<EFSalesTerritoryHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritoryHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, int territoryID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesTerritoryHistory   efSalesTerritoryHistory)
		{
			efSalesTerritoryHistory.BusinessEntityID = businessEntityID;
			efSalesTerritoryHistory.TerritoryID = territoryID;
			efSalesTerritoryHistory.StartDate = startDate;
			efSalesTerritoryHistory.EndDate = endDate;
			efSalesTerritoryHistory.Rowguid = rowguid;
			efSalesTerritoryHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTerritoryHistory efSalesTerritoryHistory,Response response)
		{
			if(efSalesTerritoryHistory == null)
			{
				return;
			}
			response.AddSalesTerritoryHistory(new POCOSalesTerritoryHistory()
			{
				StartDate = efSalesTerritoryHistory.StartDate.ToDateTime(),
				EndDate = efSalesTerritoryHistory.EndDate.ToNullableDateTime(),
				Rowguid = efSalesTerritoryHistory.Rowguid,
				ModifiedDate = efSalesTerritoryHistory.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efSalesTerritoryHistory.BusinessEntityID,
				                                            "SalesPersons"),
				TerritoryID = new ReferenceEntity<int>(efSalesTerritoryHistory.TerritoryID,
				                                       "SalesTerritories"),
			});

			SalesPersonRepository.MapEFToPOCO(efSalesTerritoryHistory.SalesPerson, response);

			SalesTerritoryRepository.MapEFToPOCO(efSalesTerritoryHistory.SalesTerritory, response);
		}
	}
}

/*<Codenesium>
    <Hash>43d24cf27dcde13f48c312776a0bc119</Hash>
</Codenesium>*/