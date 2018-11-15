using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepStatuMapper
	{
		BOPipelineStepStatu MapModelToBO(
			int id,
			ApiPipelineStepStatuServerRequestModel model);

		ApiPipelineStepStatuServerResponseModel MapBOToModel(
			BOPipelineStepStatu boPipelineStepStatu);

		List<ApiPipelineStepStatuServerResponseModel> MapBOToModel(
			List<BOPipelineStepStatu> items);
	}
}

/*<Codenesium>
    <Hash>48d6d3a1e73ce0f6b55cd5b918d4013c</Hash>
</Codenesium>*/