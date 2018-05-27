using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IDALPetMapper
	{
		void MapDTOToEF(
			int id,
			DTOPet dto,
			Pet efPet);

		DTOPet MapEFToDTO(
			Pet efPet);
	}
}

/*<Codenesium>
    <Hash>a8ac9fda02ee3d23b08f77c8a0f35c42</Hash>
</Codenesium>*/