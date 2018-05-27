using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLClaspMapper
	{
		DTOClasp MapModelToDTO(
			int id,
			ApiClaspRequestModel model);

		ApiClaspResponseModel MapDTOToModel(
			DTOClasp dtoClasp);

		List<ApiClaspResponseModel> MapDTOToModel(
			List<DTOClasp> dtos);
	}
}

/*<Codenesium>
    <Hash>79455fc285d91e42c069c6448bc923ef</Hash>
</Codenesium>*/