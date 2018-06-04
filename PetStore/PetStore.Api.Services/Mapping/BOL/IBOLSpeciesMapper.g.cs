using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public interface IBOLSpeciesMapper
	{
		BOSpecies MapModelToBO(
			int id,
			ApiSpeciesRequestModel model);

		ApiSpeciesResponseModel MapBOToModel(
			BOSpecies boSpecies);

		List<ApiSpeciesResponseModel> MapBOToModel(
			List<BOSpecies> bos);
	}
}

/*<Codenesium>
    <Hash>f6781f6398a9981bc44df5972703e350</Hash>
</Codenesium>*/