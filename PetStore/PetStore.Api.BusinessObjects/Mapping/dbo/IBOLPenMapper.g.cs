using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOLPenMapper
	{
		DTOPen MapModelToDTO(
			int id,
			ApiPenRequestModel model);

		ApiPenResponseModel MapDTOToModel(
			DTOPen dtoPen);

		List<ApiPenResponseModel> MapDTOToModel(
			List<DTOPen> dtos);
	}
}

/*<Codenesium>
    <Hash>0a0778c222b58c500f6285d979da58fc</Hash>
</Codenesium>*/