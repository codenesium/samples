using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesTerritoryMapper
	{
		public virtual SalesTerritory MapModelToEntity(
			int territoryID,
			ApiSalesTerritoryServerRequestModel model
			)
		{
			SalesTerritory item = new SalesTerritory();
			item.SetProperties(
				territoryID,
				model.CostLastYear,
				model.CostYTD,
				model.CountryRegionCode,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesYTD);
			return item;
		}

		public virtual ApiSalesTerritoryServerResponseModel MapEntityToModel(
			SalesTerritory item)
		{
			var model = new ApiSalesTerritoryServerResponseModel();

			model.SetProperties(item.TerritoryID,
			                    item.CostLastYear,
			                    item.CostYTD,
			                    item.CountryRegionCode,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid,
			                    item.SalesLastYear,
			                    item.SalesYTD);

			return model;
		}

		public virtual List<ApiSalesTerritoryServerResponseModel> MapEntityToModel(
			List<SalesTerritory> items)
		{
			List<ApiSalesTerritoryServerResponseModel> response = new List<ApiSalesTerritoryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7046a2cc453ef55f930ef5b64bab1081</Hash>
</Codenesium>*/