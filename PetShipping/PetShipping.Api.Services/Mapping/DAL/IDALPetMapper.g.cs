using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>3fa822d7eeb843fe0bb5b98fa474291c</Hash>
</Codenesium>*/