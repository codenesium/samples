using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCustomerMapper
	{
		public virtual Customer MapModelToBO(
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

		public virtual ApiCustomerServerResponseModel MapBOToModel(
			Customer item)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(item.CustomerID, item.AccountNumber, item.ModifiedDate, item.PersonID, item.Rowguid, item.StoreID, item.TerritoryID);

			return model;
		}

		public virtual List<ApiCustomerServerResponseModel> MapBOToModel(
			List<Customer> items)
		{
			List<ApiCustomerServerResponseModel> response = new List<ApiCustomerServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e0da3499953af88ad7bded60429f69f1</Hash>
</Codenesium>*/