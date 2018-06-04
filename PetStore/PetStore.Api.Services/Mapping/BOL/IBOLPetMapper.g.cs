using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
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
			List<BOPet> bos);
	}
}

/*<Codenesium>
    <Hash>49b748b889e6102a472ed2e9e4e5b89c</Hash>
</Codenesium>*/