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
			ApiPetRequestModel model);

		ApiPetResponseModel MapBOToModel(
			BOPet boPet);

		List<ApiPetResponseModel> MapBOToModel(
			List<BOPet> items);
	}
}

/*<Codenesium>
    <Hash>2c4774f0677bebb602688150986aa687</Hash>
</Codenesium>*/