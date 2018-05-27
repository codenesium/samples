using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOLBreedMapper
	{
		DTOBreed MapModelToDTO(
			int id,
			ApiBreedRequestModel model);

		ApiBreedResponseModel MapDTOToModel(
			DTOBreed dtoBreed);

		List<ApiBreedResponseModel> MapDTOToModel(
			List<DTOBreed> dtos);
	}
}

/*<Codenesium>
    <Hash>cb976f8bb49316e72d642e64571abce1</Hash>
</Codenesium>*/