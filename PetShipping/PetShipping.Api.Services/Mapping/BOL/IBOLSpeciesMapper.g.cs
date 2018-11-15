using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLSpeciesMapper
	{
		BOSpecies MapModelToBO(
			int id,
			ApiSpeciesServerRequestModel model);

		ApiSpeciesServerResponseModel MapBOToModel(
			BOSpecies boSpecies);

		List<ApiSpeciesServerResponseModel> MapBOToModel(
			List<BOSpecies> items);
	}
}

/*<Codenesium>
    <Hash>fce4ba46f7d9c76c4ab0e6b8ebda79fe</Hash>
</Codenesium>*/