using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALSpaceMapper
	{
		void MapDTOToEF(
			int id,
			DTOSpace dto,
			Space efSpace);

		DTOSpace MapEFToDTO(
			Space efSpace);
	}
}

/*<Codenesium>
    <Hash>c1600726e040a9ee76a0fabc0890a35b</Hash>
</Codenesium>*/