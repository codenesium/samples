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
    <Hash>e123c7fad95eb73425e2244e6dfe832d</Hash>
</Codenesium>*/