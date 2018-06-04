using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>791dc99d575c22f0f65d9d36a617ca6f</Hash>
</Codenesium>*/