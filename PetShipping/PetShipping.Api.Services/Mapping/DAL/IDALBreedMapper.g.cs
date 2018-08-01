using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>93967136e2611e3c417b3f908a0fbe89</Hash>
</Codenesium>*/