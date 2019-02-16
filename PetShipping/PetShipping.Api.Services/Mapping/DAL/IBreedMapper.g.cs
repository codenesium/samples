using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>a0e2383defbc0f81dfb857f54c353af0</Hash>
</Codenesium>*/