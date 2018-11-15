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
			ApiPipelineStepStepRequirementServerRequestModel model);

		ApiPipelineStepStepRequirementServerResponseModel MapBOToModel(
			BOPipelineStepStepRequirement boPipelineStepStepRequirement);

		List<ApiPipelineStepStepRequirementServerResponseModel> MapBOToModel(
			List<BOPipelineStepStepRequirement> items);
	}
}

/*<Codenesium>
    <Hash>026718ae5d71f2578224ee91cdda632b</Hash>
</Codenesium>*/