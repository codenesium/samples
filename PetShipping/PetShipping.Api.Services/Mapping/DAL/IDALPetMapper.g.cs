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
    <Hash>2a5c13e531e4f61565196018bcef9b12</Hash>
</Codenesium>*/