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
	public abstract class AbstractSalesTerritoryRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractSalesTerritoryRepository(ILogger logger,
		                                        ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          string countryRegionCode,
		                          string @group,
		                          decimal salesYTD,
		                          decimal salesLastYear,
		                          decimal costYTD,
		                          decimal costLastYear,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFSalesTerritory ();

			MapPOCOToEF(0, name,
			            countryRegionCode,
			            @group,
			            salesYTD,
			            salesLastYear,
			            costYTD,
			            costLastYear,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFSalesTerritory>().Add(record);
			this._context.SaveChanges();
			return record.territoryID;
		}

		public virtual void Update(int territoryID, string name,
		                           string countryRegionCode,
		                           string @group,
		                           decimal salesYTD,
		                           decimal salesLastYear,
		                           decimal costYTD,
		                           decimal costLastYear,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.territoryID == territoryID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",territoryID);
			}
			else
			{
				MapPOCOToEF(territoryID,  name,
				            countryRegionCode,
				            @group,
				            salesYTD,
				            salesLastYear,
				            costYTD,
				            costLastYear,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int territoryID)
		{
			var record = this.SearchLinqEF(x => x.territoryID == territoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFSalesTerritory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int territoryID, Response response)
		{
			this.SearchLinqPOCO(x => x.territoryID == territoryID,response);
		}

		protected virtual List<EFSalesTerritory> SearchLinqEF(Expression<Func<EFSalesTerritory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTerritory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTerritory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFSalesTerritory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int territoryID, string name,
		                               string countryRegionCode,
		                               string @group,
		                               decimal salesYTD,
		                               decimal salesLastYear,
		                               decimal costYTD,
		                               decimal costLastYear,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFSalesTerritory   efSalesTerritory)
		{
			efSalesTerritory.territoryID = territoryID;
			efSalesTerritory.name = name;
			efSalesTerritory.countryRegionCode = countryRegionCode;
			efSalesTerritory.@group = @group;
			efSalesTerritory.salesYTD = salesYTD;
			efSalesTerritory.salesLastYear = salesLastYear;
			efSalesTerritory.costYTD = costYTD;
			efSalesTerritory.costLastYear = costLastYear;
			efSalesTerritory.rowguid = rowguid;
			efSalesTerritory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTerritory efSalesTerritory,Response response)
		{
			if(efSalesTerritory == null)
			{
				return;
			}
			response.AddSalesTerritory(new POCOSalesTerritory()
			{
				TerritoryID = efSalesTerritory.territoryID.ToInt(),
				Name = efSalesTerritory.name,
				CountryRegionCode = efSalesTerritory.countryRegionCode,
				@Group = efSalesTerritory.@group,
				SalesYTD = efSalesTerritory.salesYTD,
				SalesLastYear = efSalesTerritory.salesLastYear,
				CostYTD = efSalesTerritory.costYTD,
				CostLastYear = efSalesTerritory.costLastYear,
				Rowguid = efSalesTerritory.rowguid,
				ModifiedDate = efSalesTerritory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>bde7f545b33dc98ad6827120010cc9d1</Hash>
</Codenesium>*/