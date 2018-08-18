using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>f3747351ab42e8b5a8e3a68d732ec577</Hash>
</Codenesium>*/