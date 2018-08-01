using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IBOLSpeciesMapper
	{
		BOSpecies MapModelToBO(
			int id,
			ApiSpeciesRequestModel model);

		ApiSpeciesResponseModel MapBOToModel(
			BOSpecies boSpecies);

		List<ApiSpeciesResponseModel> MapBOToModel(
			List<BOSpecies> items);
	}
}

/*<Codenesium>
    <Hash>c363f6ce00dfd62676f21f8da11923bb</Hash>
</Codenesium>*/