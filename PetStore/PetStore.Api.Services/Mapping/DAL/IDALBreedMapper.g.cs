using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IDALBreedMapper
	{
		Breed MapBOToEF(
			BOBreed bo);

		BOBreed MapEFToBO(
			Breed efBreed);

		List<BOBreed> MapEFToBO(
			List<Breed> records);
	}
}

/*<Codenesium>
    <Hash>c4feb559413b7793f45f8ad159f0a683</Hash>
</Codenesium>*/