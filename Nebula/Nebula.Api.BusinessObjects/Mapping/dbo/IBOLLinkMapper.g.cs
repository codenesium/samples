using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLLinkMapper
	{
		DTOLink MapModelToDTO(
			int id,
			ApiLinkRequestModel model);

		ApiLinkResponseModel MapDTOToModel(
			DTOLink dtoLink);

		List<ApiLinkResponseModel> MapDTOToModel(
			List<DTOLink> dtos);
	}
}

/*<Codenesium>
    <Hash>d57039d5e52f364f07f141c76d01e0f0</Hash>
</Codenesium>*/