using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>64e40efaeb562fd71af87897c5fef535</Hash>
</Codenesium>*/