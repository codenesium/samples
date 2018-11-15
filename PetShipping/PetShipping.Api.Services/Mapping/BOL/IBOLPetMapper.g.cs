using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPetMapper
	{
		BOPet MapModelToBO(
			int id,
			ApiPetServerRequestModel model);

		ApiPetServerResponseModel MapBOToModel(
			BOPet boPet);

		List<ApiPetServerResponseModel> MapBOToModel(
			List<BOPet> items);
	}
}

/*<Codenesium>
    <Hash>dfe17f2d181d3ef9ef83b4790eecc8fe</Hash>
</Codenesium>*/