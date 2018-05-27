using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLClientMapper
	{
		DTOClient MapModelToDTO(
			int id,
			ApiClientRequestModel model);

		ApiClientResponseModel MapDTOToModel(
			DTOClient dtoClient);

		List<ApiClientResponseModel> MapDTOToModel(
			List<DTOClient> dtos);
	}
}

/*<Codenesium>
    <Hash>7a1be189805668d6b565e10e17be32bd</Hash>
</Codenesium>*/