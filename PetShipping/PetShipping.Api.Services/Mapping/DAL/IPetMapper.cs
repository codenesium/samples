using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPetMapper
	{
		Pet MapModelToEntity(
			int id,
			ApiPetServerRequestModel model);

		ApiPetServerResponseModel MapEntityToModel(
			Pet item);

		List<ApiPetServerResponseModel> MapEntityToModel(
			List<Pet> items);
	}
}

/*<Codenesium>
    <Hash>4f8687e5d09bfe908e19204185a0b700</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/