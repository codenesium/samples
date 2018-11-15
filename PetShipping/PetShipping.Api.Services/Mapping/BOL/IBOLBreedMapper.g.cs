using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>6650e6e3511e7a5ec1dcbfe7a5f9585a</Hash>
</Codenesium>*/