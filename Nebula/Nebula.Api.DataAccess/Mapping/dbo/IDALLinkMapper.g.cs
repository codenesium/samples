using System;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.DataAccess
{
	public interface IDALLinkMapper
	{
		void MapDTOToEF(
			int id,
			DTOLink dto,
			Link efLink);

		DTOLink MapEFToDTO(
			Link efLink);
	}
}

/*<Codenesium>
    <Hash>2ac48db4c15da8672df52887adbc3bc0</Hash>
</Codenesium>*/