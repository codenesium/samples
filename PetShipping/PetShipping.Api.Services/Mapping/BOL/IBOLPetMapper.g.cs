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
			ApiPetRequestModel model);

		ApiPetResponseModel MapBOToModel(
			BOPet boPet);

		List<ApiPetResponseModel> MapBOToModel(
			List<BOPet> items);
	}
}

/*<Codenesium>
    <Hash>13d5fd3d5aefd09033a3dea207aee5e1</Hash>
</Codenesium>*/