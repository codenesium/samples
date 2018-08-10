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
			ApiBreedRequestModel model);

		ApiBreedResponseModel MapBOToModel(
			BOBreed boBreed);

		List<ApiBreedResponseModel> MapBOToModel(
			List<BOBreed> items);
	}
}

/*<Codenesium>
    <Hash>7d70bb5a22b51d578fe3b66f3deb2229</Hash>
</Codenesium>*/