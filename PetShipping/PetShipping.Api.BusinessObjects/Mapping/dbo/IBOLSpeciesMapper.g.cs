using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>0891a93108e6eb417a85eca1a6e31d62</Hash>
</Codenesium>*/