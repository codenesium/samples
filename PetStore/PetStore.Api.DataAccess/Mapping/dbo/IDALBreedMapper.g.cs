using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
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
    <Hash>8753f36c356154aa40ca4fd25e7ecdf2</Hash>
</Codenesium>*/