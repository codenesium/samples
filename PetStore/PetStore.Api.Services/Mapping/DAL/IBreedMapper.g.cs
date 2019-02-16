using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALBreedMapper
	{
		Breed MapModelToEntity(
			int id,
			ApiBreedServerRequestModel model);

		ApiBreedServerResponseModel MapEntityToModel(
			Breed item);

		List<ApiBreedServerResponseModel> MapEntityToModel(
			List<Breed> items);
	}
}

/*<Codenesium>
    <Hash>b45216d8014a618c9ad6ebd86b1004a3</Hash>
</Codenesium>*/