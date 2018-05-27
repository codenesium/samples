using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALAdminMapper
	{
		void MapDTOToEF(
			int id,
			DTOAdmin dto,
			Admin efAdmin);

		DTOAdmin MapEFToDTO(
			Admin efAdmin);
	}
}

/*<Codenesium>
    <Hash>e0a6a178adb3b5055a8e67817fc55a12</Hash>
</Codenesium>*/