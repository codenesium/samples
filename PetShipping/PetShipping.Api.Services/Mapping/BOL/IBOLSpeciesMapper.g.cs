using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IBOLSpeciesMapper
	{
		BOSpecies MapModelToBO(
			int id,
			ApiSpeciesRequestModel model);

		ApiSpeciesResponseModel MapBOToModel(
			BOSpecies boSpecies);

		List<ApiSpeciesResponseModel> MapBOToModel(
			List<BOSpecies> items);
	}
}

/*<Codenesium>
    <Hash>22f7920049592f93da15eeff032d239c</Hash>
</Codenesium>*/