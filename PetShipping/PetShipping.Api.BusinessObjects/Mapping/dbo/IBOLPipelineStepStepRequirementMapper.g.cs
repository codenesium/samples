using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOLPipelineStepStepRequirementMapper
	{
		DTOPipelineStepStepRequirement MapModelToDTO(
			int id,
			ApiPipelineStepStepRequirementRequestModel model);

		ApiPipelineStepStepRequirementResponseModel MapDTOToModel(
			DTOPipelineStepStepRequirement dtoPipelineStepStepRequirement);

		List<ApiPipelineStepStepRequirementResponseModel> MapDTOToModel(
			List<DTOPipelineStepStepRequirement> dtos);
	}
}

/*<Codenesium>
    <Hash>ba8bbc89605408a5507920ce0cc03492</Hash>
</Codenesium>*/