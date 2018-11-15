using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IBOLBreedMapper
	{
		BOBreed MapModelToBO(
			int id,
			ApiBreedServerRequestModel model);

		ApiBreedServerResponseModel MapBOToModel(
			BOBreed boBreed);

		List<ApiBreedServerResponseModel> MapBOToModel(
			List<BOBreed> items);
	}
}

/*<Codenesium>
    <Hash>c899cf833180a2d3bf5f9315ef7e94e0</Hash>
</Codenesium>*/