using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepStepRequirementMapper
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
    <Hash>270bbe81e717f862e7b43ece23114a13</Hash>
</Codenesium>*/