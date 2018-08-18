using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IBOLSpeciesMapper
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
    <Hash>c510964b702fc9385057e104b2a57e39</Hash>
</Codenesium>*/