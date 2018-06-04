using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>1416406ba9ace2cf0d6eaa37774e3fe5</Hash>
</Codenesium>*/