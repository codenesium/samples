using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALStudioMapper
	{
		void MapDTOToEF(
			int id,
			DTOStudio dto,
			Studio efStudio);

		DTOStudio MapEFToDTO(
			Studio efStudio);
	}
}

/*<Codenesium>
    <Hash>fe1e4c1a161ede1580c7e65cc163adab</Hash>
</Codenesium>*/