using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCustomerMapper
	{
		public virtual Customer MapModelToEntity(
			int customerID,
			ApiCustomerServerRequestModel model
			)
		{
			Customer item = new Customer();
			item.SetProperties(
				customerID,
				model.AccountNumber,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid,
				model.StoreID,
				model.TerritoryID);
			return item;
		}

		public virtual ApiCustomerServerResponseModel MapEntityToModel(
			Customer item)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(item.CustomerID,
			                    item.AccountNumber,
			                    item.ModifiedDate,
			                    item.PersonID,
			                    item.Rowguid,
			                    item.StoreID,
			                    item.TerritoryID);
			if (item.StoreIDNavigation != null)
			{
				var storeIDModel = new ApiStoreServerResponseModel();
				storeIDModel.SetProperties(
					item.StoreIDNavigation.BusinessEntityID,
					item.StoreIDNavigation.Demographic,
					item.StoreIDNavigation.ModifiedDate,
					item.StoreIDNavigation.Name,
					item.StoreIDNavigation.Rowguid,
					item.StoreIDNavigation.SalesPersonID);

				model.SetStoreIDNavigation(storeIDModel);
			}

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
					item.TerritoryIDNavigation.ReservedGroup,
					item.TerritoryIDNavigation.Rowguid,
					item.TerritoryIDNavigation.SalesLastYear,
					item.TerritoryIDNavigation.SalesYTD);

				model.SetTerritoryIDNavigation(territoryIDModel);
			}

			return model;
		}

		public virtual List<ApiCustomerServerResponseModel> MapEntityToModel(
			List<Customer> items)
		{
			List<ApiCustomerServerResponseModel> response = new List<ApiCustomerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9bcfae6e42c996af4abbc0843367f08f</Hash>
</Codenesium>*/