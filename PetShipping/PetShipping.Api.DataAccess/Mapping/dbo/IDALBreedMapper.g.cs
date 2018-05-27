using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALBreedMapper
	{
		void MapDTOToEF(
			int id,
			DTOBreed dto,
			Breed efBreed);

		DTOBreed MapEFToDTO(
			Breed efBreed);
	}
}

/*<Codenesium>
    <Hash>7d6ffbb8cb3e58091f9c6402bfe48e7e</Hash>
</Codenesium>*/