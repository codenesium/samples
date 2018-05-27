using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLEmailAddressMapper
	{
		DTOEmailAddress MapModelToDTO(
			int businessEntityID,
			ApiEmailAddressRequestModel model);

		ApiEmailAddressResponseModel MapDTOToModel(
			DTOEmailAddress dtoEmailAddress);

		List<ApiEmailAddressResponseModel> MapDTOToModel(
			List<DTOEmailAddress> dtos);
	}
}

/*<Codenesium>
    <Hash>7c46d5dfb67ef9eb8c7a32854204dc18</Hash>
</Codenesium>*/