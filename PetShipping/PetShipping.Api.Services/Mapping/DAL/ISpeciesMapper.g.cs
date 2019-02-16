using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
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
    <Hash>895a8c433456251371340a98b55e3242</Hash>
</Codenesium>*/