using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALBreedMapper
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
    <Hash>97ccc21a94ddb4931c3bf5f8fe80dce2</Hash>
</Codenesium>*/