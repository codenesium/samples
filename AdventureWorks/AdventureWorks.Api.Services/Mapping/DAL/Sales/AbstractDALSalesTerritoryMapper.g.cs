using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesTerritoryMapper
	{
		public virtual SalesTerritory MapModelToBO(
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

		public virtual ApiSalesTerritoryServerResponseModel MapBOToModel(
			SalesTerritory item)
		{
			var model = new ApiSalesTerritoryServerResponseModel();

			model.SetProperties(item.TerritoryID, item.CostLastYear, item.CostYTD, item.CountryRegionCode, item.ModifiedDate, item.Name, item.Rowguid, item.SalesLastYear, item.SalesYTD);

			return model;
		}

		public virtual List<ApiSalesTerritoryServerResponseModel> MapBOToModel(
			List<SalesTerritory> items)
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
    <Hash>f60239da7b803dc6ec519f9fb4234d05</Hash>
</Codenesium>*/