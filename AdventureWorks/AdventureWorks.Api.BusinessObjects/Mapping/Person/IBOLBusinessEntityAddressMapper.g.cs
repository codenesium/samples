using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLBusinessEntityAddressMapper
	{
		DTOBusinessEntityAddress MapModelToDTO(
			int businessEntityID,
			ApiBusinessEntityAddressRequestModel model);

		ApiBusinessEntityAddressResponseModel MapDTOToModel(
			DTOBusinessEntityAddress dtoBusinessEntityAddress);

		List<ApiBusinessEntityAddressResponseModel> MapDTOToModel(
			List<DTOBusinessEntityAddress> dtos);
	}
}

/*<Codenesium>
    <Hash>147632722a17da28006418cb76e988f8</Hash>
</Codenesium>*/