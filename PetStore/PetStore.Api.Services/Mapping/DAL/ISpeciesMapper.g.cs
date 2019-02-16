using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public partial interface IDALSpeciesMapper
	{
		Species MapModelToEntity(
			int id,
			ApiSpeciesServerRequestModel model);

		ApiSpeciesServerResponseModel MapEntityToModel(
			Species item);

		List<ApiSpeciesServerResponseModel> MapEntityToModel(
			List<Species> items);
	}
}

/*<Codenesium>
    <Hash>91171fe2bd198e5881a254ef07b0f0c5</Hash>
</Codenesium>*/