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
			List<BOPipelineStepStepRequirement> bos);
	}
}

/*<Codenesium>
    <Hash>6b6363e4760d507984e0a5ca2a5dfb11</Hash>
</Codenesium>*/