using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTerritoryMapper
	{
		public virtual BOSalesTerritory MapModelToBO(
			int territoryID,
			ApiSalesTerritoryRequestModel model
			)
		{
			BOSalesTerritory boSalesTerritory = new BOSalesTerritory();
			boSalesTerritory.SetProperties(
				territoryID,
				model.CostLastYear,
				model.CostYTD,
				model.CountryRegionCode,
				model.@Group,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesYTD);
			return boSalesTerritory;
		}

		public virtual ApiSalesTerritoryResponseModel MapBOToModel(
			BOSalesTerritory boSalesTerritory)
		{
			var model = new ApiSalesTerritoryResponseModel();

			model.SetProperties(boSalesTerritory.TerritoryID, boSalesTerritory.CostLastYear, boSalesTerritory.CostYTD, boSalesTerritory.CountryRegionCode, boSalesTerritory.@Group, boSalesTerritory.ModifiedDate, boSalesTerritory.Name, boSalesTerritory.Rowguid, boSalesTerritory.SalesLastYear, boSalesTerritory.SalesYTD);

			return model;
		}

		public virtual List<ApiSalesTerritoryResponseModel> MapBOToModel(
			List<BOSalesTerritory> items)
		{
			List<ApiSalesTerritoryResponseModel> response = new List<ApiSalesTerritoryResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>18f1aba0856a92985367e4a60cd6ff5a</Hash>
</Codenesium>*/