using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
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
    <Hash>96dc31134540aea5aaff5a1637dd9de9</Hash>
</Codenesium>*/