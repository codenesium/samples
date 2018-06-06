using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>339f23a14e816316e96a11f98fa74b4a</Hash>
</Codenesium>*/