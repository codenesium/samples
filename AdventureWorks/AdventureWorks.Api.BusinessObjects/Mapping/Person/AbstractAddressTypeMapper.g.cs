using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAddressTypeMapper
	{
		public virtual DTOAddressType MapModelToDTO(
			int addressTypeID,
			ApiAddressTypeRequestModel model
			)
		{
			DTOAddressType dtoAddressType = new DTOAddressType();

			dtoAddressType.SetProperties(
				addressTypeID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid);
			return dtoAddressType;
		}

		public virtual ApiAddressTypeResponseModel MapDTOToModel(
			DTOAddressType dtoAddressType)
		{
			if (dtoAddressType == null)
			{
				return null;
			}

			var model = new ApiAddressTypeResponseModel();

			model.SetProperties(dtoAddressType.AddressTypeID, dtoAddressType.ModifiedDate, dtoAddressType.Name, dtoAddressType.Rowguid);

			return model;
		}

		public virtual List<ApiAddressTypeResponseModel> MapDTOToModel(
			List<DTOAddressType> dtos)
		{
			List<ApiAddressTypeResponseModel> response = new List<ApiAddressTypeResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f2eed9ef1f68b7c3d7a477e35a62e210</Hash>
</Codenesium>*/