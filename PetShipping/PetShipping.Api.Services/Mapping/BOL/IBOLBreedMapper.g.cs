using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
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
    <Hash>9fe57da45a419743d459785fc8f70c16</Hash>
</Codenesium>*/