using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALStateMapper
	{
		void MapDTOToEF(
			int id,
			DTOState dto,
			State efState);

		DTOState MapEFToDTO(
			State efState);
	}
}

/*<Codenesium>
    <Hash>33a9229e380ac59cba1830a9d8999974</Hash>
</Codenesium>*/