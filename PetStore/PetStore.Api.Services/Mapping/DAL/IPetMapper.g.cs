using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
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
    <Hash>d473c353db0282a648ab467a2eb048be</Hash>
</Codenesium>*/