using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCustomerMapper
	{
		public virtual BOCustomer MapModelToBO(
			int customerID,
			ApiCustomerServerRequestModel model
			)
		{
			BOCustomer boCustomer = new BOCustomer();
			boCustomer.SetProperties(
				customerID,
				model.AccountNumber,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid,
				model.StoreID,
				model.TerritoryID);
			return boCustomer;
		}

		public virtual ApiCustomerServerResponseModel MapBOToModel(
			BOCustomer boCustomer)
		{
			var model = new ApiCustomerServerResponseModel();

			model.SetProperties(boCustomer.CustomerID, boCustomer.AccountNumber, boCustomer.ModifiedDate, boCustomer.PersonID, boCustomer.Rowguid, boCustomer.StoreID, boCustomer.TerritoryID);

			return model;
		}

		public virtual List<ApiCustomerServerResponseModel> MapBOToModel(
			List<BOCustomer> items)
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
    <Hash>f4ce123686dafc2c5cf871490e2232f3</Hash>
</Codenesium>*/