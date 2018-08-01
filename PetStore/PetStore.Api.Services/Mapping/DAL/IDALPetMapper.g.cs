using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>b9173f3bc6416ca78ae34058baf9579c</Hash>
</Codenesium>*/