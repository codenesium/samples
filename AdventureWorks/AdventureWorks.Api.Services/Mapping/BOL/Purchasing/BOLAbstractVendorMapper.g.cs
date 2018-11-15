using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractVendorMapper
	{
		public virtual BOVendor MapModelToBO(
			int businessEntityID,
			ApiVendorServerRequestModel model
			)
		{
			BOVendor boVendor = new BOVendor();
			boVendor.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.ActiveFlag,
				model.CreditRating,
				model.ModifiedDate,
				model.Name,
				model.PreferredVendorStatu,
				model.PurchasingWebServiceURL);
			return boVendor;
		}

		public virtual ApiVendorServerResponseModel MapBOToModel(
			BOVendor boVendor)
		{
			var model = new ApiVendorServerResponseModel();

			model.SetProperties(boVendor.BusinessEntityID, boVendor.AccountNumber, boVendor.ActiveFlag, boVendor.CreditRating, boVendor.ModifiedDate, boVendor.Name, boVendor.PreferredVendorStatu, boVendor.PurchasingWebServiceURL);

			return model;
		}

		public virtual List<ApiVendorServerResponseModel> MapBOToModel(
			List<BOVendor> items)
		{
			List<ApiVendorServerResponseModel> response = new List<ApiVendorServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e83da9c968494b1a77b8d3c6e6f1a2f6</Hash>
</Codenesium>*/