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
			ApiPipelineStepDestinationServerRequestModel model);

		ApiPipelineStepDestinationServerResponseModel MapBOToModel(
			BOPipelineStepDestination boPipelineStepDestination);

		List<ApiPipelineStepDestinationServerResponseModel> MapBOToModel(
			List<BOPipelineStepDestination> items);
	}
}

/*<Codenesium>
    <Hash>ff5723b25821f2ab91cdaa46977ddf67</Hash>
</Codenesium>*/