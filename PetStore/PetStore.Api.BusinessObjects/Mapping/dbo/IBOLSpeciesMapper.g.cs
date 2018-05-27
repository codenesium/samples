using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOLSpeciesMapper
	{
		DTOSpecies MapModelToDTO(
			int id,
			ApiSpeciesRequestModel model);

		ApiSpeciesResponseModel MapDTOToModel(
			DTOSpecies dtoSpecies);

		List<ApiSpeciesResponseModel> MapDTOToModel(
			List<DTOSpecies> dtos);
	}
}

/*<Codenesium>
    <Hash>564c97191684a3dbd21a0847d52f33f7</Hash>
</Codenesium>*/