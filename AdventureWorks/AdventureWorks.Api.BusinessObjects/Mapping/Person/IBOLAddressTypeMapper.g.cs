using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLAddressTypeMapper
	{
		DTOAddressType MapModelToDTO(
			int addressTypeID,
			ApiAddressTypeRequestModel model);

		ApiAddressTypeResponseModel MapDTOToModel(
			DTOAddressType dtoAddressType);

		List<ApiAddressTypeResponseModel> MapDTOToModel(
			List<DTOAddressType> dtos);
	}
}

/*<Codenesium>
    <Hash>5a36c51bb4b61ffb253109127857737c</Hash>
</Codenesium>*/