using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALSpeciesMapper
	{
		Species MapBOToEF(
			BOSpecies bo);

		BOSpecies MapEFToBO(
			Species efSpecies);

		List<BOSpecies> MapEFToBO(
			List<Species> records);
	}
}

/*<Codenesium>
    <Hash>22ea945229e0563f04c25831763bfaab</Hash>
</Codenesium>*/