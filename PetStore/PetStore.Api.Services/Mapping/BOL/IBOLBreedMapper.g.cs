using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public interface IBOLBreedMapper
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
    <Hash>5d19957b2ea3dcb76e8d1a1f7ba2b866</Hash>
</Codenesium>*/