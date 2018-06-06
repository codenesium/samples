using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepStepRequirementMapper
	{
		BOPipelineStepStepRequirement MapModelToBO(
			int id,
			ApiPipelineStepStepRequirementRequestModel model);

		ApiPipelineStepStepRequirementResponseModel MapBOToModel(
			BOPipelineStepStepRequirement boPipelineStepStepRequirement);

		List<ApiPipelineStepStepRequirementResponseModel> MapBOToModel(
			List<BOPipelineStepStepRequirement> items);
	}
}

/*<Codenesium>
    <Hash>d713bef5037c062a90cd876b8cb96355</Hash>
</Codenesium>*/