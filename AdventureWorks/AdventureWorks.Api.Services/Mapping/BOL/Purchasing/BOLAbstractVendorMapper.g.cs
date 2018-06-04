using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractVendorMapper
	{
		public virtual BOVendor MapModelToBO(
			int businessEntityID,
			ApiVendorRequestModel model
			)
		{
			BOVendor BOVendor = new BOVendor();

			BOVendor.SetProperties(
				businessEntityID,
				model.AccountNumber,
				model.ActiveFlag,
				model.CreditRating,
				model.ModifiedDate,
				model.Name,
				model.PreferredVendorStatus,
				model.PurchasingWebServiceURL);
			return BOVendor;
		}

		public virtual ApiVendorResponseModel MapBOToModel(
			BOVendor BOVendor)
		{
			if (BOVendor == null)
			{
				return null;
			}

			var model = new ApiVendorResponseModel();

			model.SetProperties(BOVendor.AccountNumber, BOVendor.ActiveFlag, BOVendor.BusinessEntityID, BOVendor.CreditRating, BOVendor.ModifiedDate, BOVendor.Name, BOVendor.PreferredVendorStatus, BOVendor.PurchasingWebServiceURL);

			return model;
		}

		public virtual List<ApiVendorResponseModel> MapBOToModel(
			List<BOVendor> BOs)
		{
			List<ApiVendorResponseModel> response = new List<ApiVendorResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd70cf4d1a5bf394eada600e69c3c1ae</Hash>
</Codenesium>*/