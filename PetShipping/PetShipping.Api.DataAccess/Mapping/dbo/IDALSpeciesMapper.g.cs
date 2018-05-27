using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
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
    <Hash>b70522265d76ceeb6939d5bb0d93c277</Hash>
</Codenesium>*/