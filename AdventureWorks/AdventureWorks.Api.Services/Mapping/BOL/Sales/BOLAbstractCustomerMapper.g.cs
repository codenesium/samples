using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractCustomerMapper
	{
		public virtual BOCustomer MapModelToBO(
			int customerID,
			ApiCustomerRequestModel model
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

		public virtual ApiCustomerResponseModel MapBOToModel(
			BOCustomer boCustomer)
		{
			var model = new ApiCustomerResponseModel();

			model.SetProperties(boCustomer.AccountNumber, boCustomer.CustomerID, boCustomer.ModifiedDate, boCustomer.PersonID, boCustomer.Rowguid, boCustomer.StoreID, boCustomer.TerritoryID);

			return model;
		}

		public virtual List<ApiCustomerResponseModel> MapBOToModel(
			List<BOCustomer> items)
		{
			List<ApiCustomerResponseModel> response = new List<ApiCustomerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1855528487029d65df88019368a51793</Hash>
</Codenesium>*/