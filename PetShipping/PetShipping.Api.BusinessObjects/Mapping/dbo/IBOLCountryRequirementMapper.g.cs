using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLCountryRequirementMapper
	{
		DTOCountryRequirement MapModelToDTO(
			int id,
			ApiCountryRequirementRequestModel model);

		ApiCountryRequirementResponseModel MapDTOToModel(
			DTOCountryRequirement dtoCountryRequirement);

		List<ApiCountryRequirementResponseModel> MapDTOToModel(
			List<DTOCountryRequirement> dtos);
	}
}

/*<Codenesium>
    <Hash>5b67f4b217cf04c8aac547f00d2360be</Hash>
</Codenesium>*/