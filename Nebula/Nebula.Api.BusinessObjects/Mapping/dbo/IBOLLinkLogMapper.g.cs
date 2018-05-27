using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLLinkLogMapper
	{
		DTOLinkLog MapModelToDTO(
			int id,
			ApiLinkLogRequestModel model);

		ApiLinkLogResponseModel MapDTOToModel(
			DTOLinkLog dtoLinkLog);

		List<ApiLinkLogResponseModel> MapDTOToModel(
			List<DTOLinkLog> dtos);
	}
}

/*<Codenesium>
    <Hash>5ac0406621444cc3ee48bc49ab8e7470</Hash>
</Codenesium>*/