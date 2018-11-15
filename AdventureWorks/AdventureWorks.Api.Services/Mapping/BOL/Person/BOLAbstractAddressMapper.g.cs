using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractAddressMapper
	{
		public virtual BOAddress MapModelToBO(
			int addressID,
			ApiAddressServerRequestModel model
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

		public virtual ApiAddressServerResponseModel MapBOToModel(
			BOAddress boAddress)
		{
			var model = new ApiAddressServerResponseModel();

			model.SetProperties(boAddress.AddressID, boAddress.AddressLine1, boAddress.AddressLine2, boAddress.City, boAddress.ModifiedDate, boAddress.PostalCode, boAddress.Rowguid, boAddress.StateProvinceID);

			return model;
		}

		public virtual List<ApiAddressServerResponseModel> MapBOToModel(
			List<BOAddress> items)
		{
			List<ApiAddressServerResponseModel> response = new List<ApiAddressServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>eca9fbdf10d88258cdb2eea28739845e</Hash>
</Codenesium>*/