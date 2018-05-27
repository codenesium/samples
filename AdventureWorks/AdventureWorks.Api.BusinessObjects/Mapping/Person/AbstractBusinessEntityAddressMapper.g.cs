using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLBusinessEntityAddressMapper
	{
		public virtual DTOBusinessEntityAddress MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model
			)
		{
			DTOBusinessEntityAddress dtoBusinessEntityAddress = new DTOBusinessEntityAddress();

			dtoBusinessEntityAddress.SetProperties(
				businessEntityID,
				model.AddressID,
				model.AddressTypeID,
				model.ModifiedDate,
				model.Rowguid);
			return dtoBusinessEntityAddress;
		}

		public virtual ApiBusinessEntityAddressResponseModel MapDTOToModel(
			DTOBusinessEntityAddress dtoBusinessEntityAddress)
		{
			if (dtoBusinessEntityAddress == null)
			{
				return null;
			}

			var model = new ApiBusinessEntityAddressResponseModel();

			model.SetProperties(dtoBusinessEntityAddress.AddressID, dtoBusinessEntityAddress.AddressTypeID, dtoBusinessEntityAddress.BusinessEntityID, dtoBusinessEntityAddress.ModifiedDate, dtoBusinessEntityAddress.Rowguid);

			return model;
		}

		public virtual List<ApiBusinessEntityAddressResponseModel> MapDTOToModel(
			List<DTOBusinessEntityAddress> dtos)
		{
			List<ApiBusinessEntityAddressResponseModel> response = new List<ApiBusinessEntityAddressResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>686f49aa04befbf17ce0e61cd1a09916</Hash>
</Codenesium>*/