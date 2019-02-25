using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALSalesPersonMapper
	{
		public virtual SalesPerson MapModelToEntity(
			int businessEntityID,
			ApiSalesPersonServerRequestModel model
			)
		{
			SalesPerson item = new SalesPerson();
			item.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
			return item;
		}

		public virtual ApiSalesPersonServerResponseModel MapEntityToModel(
			SalesPerson item)
		{
			var model = new ApiSalesPersonServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.Bonus,
			                    item.CommissionPct,
			                    item.ModifiedDate,
			                    item.Rowguid,
			                    item.SalesLastYear,
			                    item.SalesQuota,
			                    item.SalesYTD,
			                    item.TerritoryID);
			if (item.TerritoryIDNavigation != null)
			{
				var territoryIDModel = new ApiSalesTerritoryServerResponseModel();
				territoryIDModel.SetProperties(
					item.TerritoryIDNavigation.TerritoryID,
					item.TerritoryIDNavigation.CostLastYear,
					item.TerritoryIDNavigation.CostYTD,
					item.TerritoryIDNavigation.CountryRegionCode,
					item.TerritoryIDNavigation.ModifiedDate,
					item.TerritoryIDNavigation.Name,
					item.TerritoryIDNavigation.Rowguid,
					item.TerritoryIDNavigation.SalesLastYear,
					item.TerritoryIDNavigation.SalesYTD);

				model.SetTerritoryIDNavigation(territoryIDModel);
			}

			return model;
		}

		public virtual List<ApiSalesPersonServerResponseModel> MapEntityToModel(
			List<SalesPerson> items)
		{
			List<ApiSalesPersonServerResponseModel> response = new List<ApiSalesPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>555a26d9cde5309cfc711d8a7229a4b1</Hash>
</Codenesium>*/