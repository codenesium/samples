using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLTeamMapper
	{
		DTOTeam MapModelToDTO(
			int id,
			ApiTeamRequestModel model);

		ApiTeamResponseModel MapDTOToModel(
			DTOTeam dtoTeam);

		List<ApiTeamResponseModel> MapDTOToModel(
			List<DTOTeam> dtos);
	}
}

/*<Codenesium>
    <Hash>c3e7cb572cf537a0ca6ed2aca83328f5</Hash>
</Codenesium>*/