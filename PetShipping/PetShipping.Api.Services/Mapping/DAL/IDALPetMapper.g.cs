using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALPetMapper
	{
		Pet MapBOToEF(
			BOPet bo);

		BOPet MapEFToBO(
			Pet efPet);

		List<BOPet> MapEFToBO(
			List<Pet> records);
	}
}

/*<Codenesium>
    <Hash>8617ec4f3af4c1d62b215ace99a75edd</Hash>
</Codenesium>*/