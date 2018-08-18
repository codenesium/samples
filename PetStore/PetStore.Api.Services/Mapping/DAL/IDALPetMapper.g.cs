using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALPetMapper
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
    <Hash>a3c28adb10e8f6eec4de11fc6c5e296d</Hash>
</Codenesium>*/