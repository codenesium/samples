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
    <Hash>db20adabc8f764d85a631d48ba761fc9</Hash>
</Codenesium>*/