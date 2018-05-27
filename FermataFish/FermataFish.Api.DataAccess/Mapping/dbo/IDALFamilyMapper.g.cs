using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IDALFamilyMapper
	{
		void MapDTOToEF(
			int id,
			DTOFamily dto,
			Family efFamily);

		DTOFamily MapEFToDTO(
			Family efFamily);
	}
}

/*<Codenesium>
    <Hash>28f60f90a0ccd1c9343d372c5ae6ffce</Hash>
</Codenesium>*/