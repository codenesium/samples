using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
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
    <Hash>9c75db869ad74425a444b3dfe5b84df1</Hash>
</Codenesium>*/