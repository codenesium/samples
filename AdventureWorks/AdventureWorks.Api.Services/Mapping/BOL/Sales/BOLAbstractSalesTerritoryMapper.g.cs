using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractSalesTerritoryMapper
	{
		public virtual BOSalesTerritory MapModelToBO(
			int territoryID,
			ApiSalesTerritoryRequestModel model
			)
		{
			BOSalesTerritory BOSalesTerritory = new BOSalesTerritory();

			BOSalesTerritory.SetProperties(
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
			return BOSalesTerritory;
		}

		public virtual ApiSalesTerritoryResponseModel MapBOToModel(
			BOSalesTerritory BOSalesTerritory)
		{
			if (BOSalesTerritory == null)
			{
				return null;
			}

			var model = new ApiSalesTerritoryResponseModel();

			model.SetProperties(BOSalesTerritory.CostLastYear, BOSalesTerritory.CostYTD, BOSalesTerritory.CountryRegionCode, BOSalesTerritory.@Group, BOSalesTerritory.ModifiedDate, BOSalesTerritory.Name, BOSalesTerritory.Rowguid, BOSalesTerritory.SalesLastYear, BOSalesTerritory.SalesYTD, BOSalesTerritory.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesTerritoryResponseModel> MapBOToModel(
			List<BOSalesTerritory> BOs)
		{
			List<ApiSalesTerritoryResponseModel> response = new List<ApiSalesTerritoryResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>53c81cb3145a0c169a4bb1b3bb7b2f01</Hash>
</Codenesium>*/