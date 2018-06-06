using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
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
    <Hash>6f45d26190722ba62ede0bcd2232cf8b</Hash>
</Codenesium>*/