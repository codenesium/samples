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
    <Hash>75c6a47972d671cf884c4de83f04e369</Hash>
</Codenesium>*/