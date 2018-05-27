using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPetMapper
	{
		DTOPet MapModelToDTO(
			int id,
			ApiPetRequestModel model);

		ApiPetResponseModel MapDTOToModel(
			DTOPet dtoPet);

		List<ApiPetResponseModel> MapDTOToModel(
			List<DTOPet> dtos);
	}
}

/*<Codenesium>
    <Hash>98bb8c2977c7e7d3f8a219a66c70cc77</Hash>
</Codenesium>*/