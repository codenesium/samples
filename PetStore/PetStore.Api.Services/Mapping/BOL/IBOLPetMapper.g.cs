using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public interface IBOLPetMapper
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
    <Hash>78796492abc434611ae79d228fca9a14</Hash>
</Codenesium>*/