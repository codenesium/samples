using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>4e8a34da73b14ebdfb6cd0ac76afae8b</Hash>
</Codenesium>*/