using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALVendorMapper
	{
		public virtual Vendor MapModelToEntity(
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

		public virtual ApiVendorServerResponseModel MapEntityToModel(
			Vendor item)
		{
			var model = new ApiVendorServerResponseModel();

			model.SetProperties(item.BusinessEntityID,
			                    item.AccountNumber,
			                    item.ActiveFlag,
			                    item.CreditRating,
			                    item.ModifiedDate,
			                    item.Name,
			                    item.PreferredVendorStatu,
			                    item.PurchasingWebServiceURL);

			return model;
		}

		public virtual List<ApiVendorServerResponseModel> MapEntityToModel(
			List<Vendor> items)
		{
			List<ApiVendorServerResponseModel> response = new List<ApiVendorServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9be40f35c4d33f249919ed9898b983c7</Hash>
</Codenesium>*/