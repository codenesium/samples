using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStepRequirementMapper
	{
		PipelineStepStepRequirement MapModelToEntity(
			int id,
			ApiPipelineStepStepRequirementServerRequestModel model);

		ApiPipelineStepStepRequirementServerResponseModel MapEntityToModel(
			PipelineStepStepRequirement item);

		List<ApiPipelineStepStepRequirementServerResponseModel> MapEntityToModel(
			List<PipelineStepStepRequirement> items);
	}
}

/*<Codenesium>
    <Hash>4c4f832b300ffe4331d008db74052444</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/