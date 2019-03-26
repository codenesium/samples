using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALStoreMapper
	{
		public virtual Store MapModelToEntity(
			int businessEntityID,
			ApiStoreServerRequestModel model
			)
		{
			Store item = new Store();
			item.SetProperties(
				businessEntityID,
				model.Demographic,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
			return item;
		}

		public virtual ApiStoreServerResponseModel MapEntityToModel(
			Store item)
		{
			var model = new ApiStoreServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.Demographic,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.Rowguid,
			                    item.SalesPersonID);
			if (item.SalesPersonIDNavigation != null)
			{
				var salesPersonIDModel = new ApiSalesPersonServerResponseModel();
				salesPersonIDModel.SetProperties(
					item.SalesPersonIDNavigation.BusinessEntityID,
					item.SalesPersonIDNavigation.Bonus,
					item.SalesPersonIDNavigation.CommissionPct,
					item.SalesPersonIDNavigation.ModifiedDate,
					item.SalesPersonIDNavigation.Rowguid,
					item.SalesPersonIDNavigation.SalesLastYear,
					item.SalesPersonIDNavigation.SalesQuota,
					item.SalesPersonIDNavigation.SalesYTD,
					item.SalesPersonIDNavigation.TerritoryID);

				model.SetSalesPersonIDNavigation(salesPersonIDModel);
			}

			return model;
		}

		public virtual List<ApiStoreServerResponseModel> MapEntityToModel(
			List<Store> items)
		{
			List<ApiStoreServerResponseModel> response = new List<ApiStoreServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2f37f54311c4797c7b4007524112c318</Hash>
</Codenesium>*/