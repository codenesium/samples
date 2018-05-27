using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALTeamMapper
	{
		void MapDTOToEF(
			int id,
			DTOTeam dto,
			Team efTeam);

		DTOTeam MapEFToDTO(
			Team efTeam);
	}
}

/*<Codenesium>
    <Hash>f412a7e9440dfae42ca69a98f44e66b9</Hash>
</Codenesium>*/