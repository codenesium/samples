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
			ApiSpeciesServerRequestModel model);

		ApiSpeciesServerResponseModel MapBOToModel(
			BOSpecies boSpecies);

		List<ApiSpeciesServerResponseModel> MapBOToModel(
			List<BOSpecies> items);
	}
}

/*<Codenesium>
    <Hash>65c1502d64fa4e9f087e69d6de3ced45</Hash>
</Codenesium>*/