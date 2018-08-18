using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStepDestinationMapper
	{
		BOPipelineStepDestination MapModelToBO(
			int id,
			ApiPipelineStepDestinationRequestModel model);

		ApiPipelineStepDestinationResponseModel MapBOToModel(
			BOPipelineStepDestination boPipelineStepDestination);

		List<ApiPipelineStepDestinationResponseModel> MapBOToModel(
			List<BOPipelineStepDestination> items);
	}
}

/*<Codenesium>
    <Hash>87c27a7fbf16037d5caf6626d08feacf</Hash>
</Codenesium>*/