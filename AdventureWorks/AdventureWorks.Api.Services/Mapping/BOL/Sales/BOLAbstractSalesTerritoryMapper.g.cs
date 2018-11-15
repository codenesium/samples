using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTerritoryMapper
	{
		public virtual BOSalesTerritory MapModelToBO(
			int territoryID,
			ApiSalesTerritoryServerRequestModel model
			)
		{
			BOSalesTerritory boSalesTerritory = new BOSalesTerritory();
			boSalesTerritory.SetProperties(
				territoryID,
				model.@Group,
				model.CostLastYear,
				model.CostYTD,
				model.CountryRegionCode,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesYTD);
			return boSalesTerritory;
		}

		public virtual ApiSalesTerritoryServerResponseModel MapBOToModel(
			BOSalesTerritory boSalesTerritory)
		{
			var model = new ApiSalesTerritoryServerResponseModel();

			model.SetProperties(boSalesTerritory.TerritoryID, boSalesTerritory.@Group, boSalesTerritory.CostLastYear, boSalesTerritory.CostYTD, boSalesTerritory.CountryRegionCode, boSalesTerritory.ModifiedDate, boSalesTerritory.Name, boSalesTerritory.Rowguid, boSalesTerritory.SalesLastYear, boSalesTerritory.SalesYTD);

			return model;
		}

		public virtual List<ApiSalesTerritoryServerResponseModel> MapBOToModel(
			List<BOSalesTerritory> items)
		{
			List<ApiSalesTerritoryServerResponseModel> response = new List<ApiSalesTerritoryServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6f545d679e6e22332224d87fc29e6bbb</Hash>
</Codenesium>*/