using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALSpeciesMapper
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
    <Hash>d897865ec0b41c3b3fb6efb811f5e6cf</Hash>
</Codenesium>*/