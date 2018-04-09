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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractSalesTerritoryRepository(ILogger logger,
		                                        ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFSalesTerritory>().Add(record);
			this.context.SaveChanges();
			return record.TerritoryID;
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
			var record =  this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",territoryID);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int territoryID)
		{
			var record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesTerritory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int territoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TerritoryID == territoryID,response);
			return response;
		}

		public virtual POCOSalesTerritory GetByIdDirect(int territoryID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.TerritoryID == territoryID,response);
			return response.SalesTerritories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesTerritories;
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

		protected virtual List<EFSalesTerritory> SearchLinqEF(Expression<Func<EFSalesTerritory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efSalesTerritory.TerritoryID = territoryID;
			efSalesTerritory.Name = name;
			efSalesTerritory.CountryRegionCode = countryRegionCode;
			efSalesTerritory.@Group = @group;
			efSalesTerritory.SalesYTD = salesYTD;
			efSalesTerritory.SalesLastYear = salesLastYear;
			efSalesTerritory.CostYTD = costYTD;
			efSalesTerritory.CostLastYear = costLastYear;
			efSalesTerritory.Rowguid = rowguid;
			efSalesTerritory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFSalesTerritory efSalesTerritory,Response response)
		{
			if(efSalesTerritory == null)
			{
				return;
			}
			response.AddSalesTerritory(new POCOSalesTerritory()
			{
				TerritoryID = efSalesTerritory.TerritoryID.ToInt(),
				Name = efSalesTerritory.Name,
				@Group = efSalesTerritory.@Group,
				SalesYTD = efSalesTerritory.SalesYTD,
				SalesLastYear = efSalesTerritory.SalesLastYear,
				CostYTD = efSalesTerritory.CostYTD,
				CostLastYear = efSalesTerritory.CostLastYear,
				Rowguid = efSalesTerritory.Rowguid,
				ModifiedDate = efSalesTerritory.ModifiedDate.ToDateTime(),

				CountryRegionCode = new ReferenceEntity<string>(efSalesTerritory.CountryRegionCode,
				                                                "CountryRegions"),
			});

			CountryRegionRepository.MapEFToPOCO(efSalesTerritory.CountryRegion, response);
		}
	}
}

/*<Codenesium>
    <Hash>071b228aaaee30b99be42f3c8dfcc95c</Hash>
</Codenesium>*/