using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALVendorMapper
	{
		public virtual Vendor MapModelToBO(
			int businessEntityID,
			ApiVendorServerRequestModel model
			)
		{
			Vendor item = new Vendor();
			item.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.ActiveFlag,
				model.CreditRating,
				model.ModifiedDate,
				model.Name,
				model.PreferredVendorStatu,
				model.PurchasingWebServiceURL);
			return item;
		}

		public virtual ApiVendorServerResponseModel MapBOToModel(
			Vendor item)
		{
			var model = new ApiVendorServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.AccountNumber, item.ActiveFlag, item.CreditRating, item.ModifiedDate, item.Name, item.PreferredVendorStatu, item.PurchasingWebServiceURL);

			return model;
		}

		public virtual List<ApiVendorServerResponseModel> MapBOToModel(
			List<Vendor> items)
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
    <Hash>188b2d8adadbf1b4d336a72eb827beaa</Hash>
</Codenesium>*/