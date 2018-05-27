using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAddressMapper
	{
		public virtual DTOAddress MapModelToDTO(
			int addressID,
			ApiAddressRequestModel model
			)
		{
			DTOAddress dtoAddress = new DTOAddress();

			dtoAddress.SetProperties(
				addressID,
				model.AddressLine1,
				model.AddressLine2,
				model.City,
				model.ModifiedDate,
				model.PostalCode,
				model.Rowguid,
				model.StateProvinceID);
			return dtoAddress;
		}

		public virtual ApiAddressResponseModel MapDTOToModel(
			DTOAddress dtoAddress)
		{
			if (dtoAddress == null)
			{
				return null;
			}

			var model = new ApiAddressResponseModel();

			model.SetProperties(dtoAddress.AddressID, dtoAddress.AddressLine1, dtoAddress.AddressLine2, dtoAddress.City, dtoAddress.ModifiedDate, dtoAddress.PostalCode, dtoAddress.Rowguid, dtoAddress.StateProvinceID);

			return model;
		}

		public virtual List<ApiAddressResponseModel> MapDTOToModel(
			List<DTOAddress> dtos)
		{
			List<ApiAddressResponseModel> response = new List<ApiAddressResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>56927031119090c072da859843a7539c</Hash>
</Codenesium>*/