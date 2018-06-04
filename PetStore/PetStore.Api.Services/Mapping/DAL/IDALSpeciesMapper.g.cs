using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
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
    <Hash>d559c6d46c047c8b1078aa285deb63c6</Hash>
</Codenesium>*/