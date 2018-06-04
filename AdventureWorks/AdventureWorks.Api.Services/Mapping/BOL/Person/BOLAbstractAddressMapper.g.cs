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
			BOAddress BOAddress = new BOAddress();

			BOAddress.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.ModifiedDate,
				model.PostalCode,
				model.Rowguid,
				model.StateProvinceID);
			return BOAddress;
		}

		public virtual ApiAddressResponseModel MapBOToModel(
			BOAddress BOAddress)
		{
			if (BOAddress == null)
			{
				return null;
			}

			var model = new ApiAddressResponseModel();

			model.SetProperties(BOAddress.AddressID, BOAddress.AddressLine1, BOAddress.AddressLine2, BOAddress.City, BOAddress.ModifiedDate, BOAddress.PostalCode, BOAddress.Rowguid, BOAddress.StateProvinceID);

			return model;
		}

		public virtual List<ApiAddressResponseModel> MapBOToModel(
			List<BOAddress> BOs)
		{
			List<ApiAddressResponseModel> response = new List<ApiAddressResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>367de6c9895ce457d5dee65e91142e3c</Hash>
</Codenesium>*/