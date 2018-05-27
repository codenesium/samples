using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IDALSpeciesMapper
	{
		void MapDTOToEF(
			int id,
			DTOSpecies dto,
			Species efSpecies);

		DTOSpecies MapEFToDTO(
			Species efSpecies);
	}
}

/*<Codenesium>
    <Hash>41eecdbeafdea02fa2ae5121f01644fb</Hash>
</Codenesium>*/