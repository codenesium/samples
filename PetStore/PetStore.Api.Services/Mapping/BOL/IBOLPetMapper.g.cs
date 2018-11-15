using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>4a408f43372a3866467fa91f1d841707</Hash>
</Codenesium>*/