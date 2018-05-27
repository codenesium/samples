using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLAddressMapper
	{
		DTOAddress MapModelToDTO(
			int addressID,
			ApiAddressRequestModel model);

		ApiAddressResponseModel MapDTOToModel(
			DTOAddress dtoAddress);

		List<ApiAddressResponseModel> MapDTOToModel(
			List<DTOAddress> dtos);
	}
}

/*<Codenesium>
    <Hash>27bdfe8408f7504148fbd92ddfbf036f</Hash>
</Codenesium>*/