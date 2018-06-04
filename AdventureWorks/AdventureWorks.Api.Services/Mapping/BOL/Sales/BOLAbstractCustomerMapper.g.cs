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
			BOCustomer BOCustomer = new BOCustomer();

			BOCustomer.SetProperties(
				customerID,
				model.AccountNumber,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid,
				model.StoreID,
				model.TerritoryID);
			return BOCustomer;
		}

		public virtual ApiCustomerResponseModel MapBOToModel(
			BOCustomer BOCustomer)
		{
			if (BOCustomer == null)
			{
				return null;
			}

			var model = new ApiCustomerResponseModel();

			model.SetProperties(BOCustomer.AccountNumber, BOCustomer.CustomerID, BOCustomer.ModifiedDate, BOCustomer.PersonID, BOCustomer.Rowguid, BOCustomer.StoreID, BOCustomer.TerritoryID);

			return model;
		}

		public virtual List<ApiCustomerResponseModel> MapBOToModel(
			List<BOCustomer> BOs)
		{
			List<ApiCustomerResponseModel> response = new List<ApiCustomerResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>055cd4f2a9305d99e6d6e613582b80a9</Hash>
</Codenesium>*/