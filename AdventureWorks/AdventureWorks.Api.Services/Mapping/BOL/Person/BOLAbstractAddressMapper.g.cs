using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAddressMapper
	{
		public virtual BOAddress MapModelToBO(
			int addressID,
			ApiAddressRequestModel model
			)
		{
			BOAddress boAddress = new BOAddress();
			boAddress.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.ModifiedDate,
				model.PostalCode,
				model.Rowguid,
				model.StateProvinceID);
			return boAddress;
		}

		public virtual ApiAddressResponseModel MapBOToModel(
			BOAddress boAddress)
		{
			var model = new ApiAddressResponseModel();

			model.SetProperties(boAddress.AddressID, boAddress.AddressLine1, boAddress.AddressLine2, boAddress.City, boAddress.ModifiedDate, boAddress.PostalCode, boAddress.Rowguid, boAddress.StateProvinceID);

			return model;
		}

		public virtual List<ApiAddressResponseModel> MapBOToModel(
			List<BOAddress> items)
		{
			List<ApiAddressResponseModel> response = new List<ApiAddressResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3c8d06faf587ae8cb3dbd4aa4b3bc4c9</Hash>
</Codenesium>*/