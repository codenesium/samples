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
			ApiBreedRequestModel model);

		ApiBreedResponseModel MapBOToModel(
			BOBreed boBreed);

		List<ApiBreedResponseModel> MapBOToModel(
			List<BOBreed> items);
	}
}

/*<Codenesium>
    <Hash>99e3504c3df8acbca76a3f5936c32b2f</Hash>
</Codenesium>*/