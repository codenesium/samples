using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLPipelineStepDestinationMapper
	{
		BOPipelineStepDestination MapModelToBO(
			int id,
			ApiPipelineStepDestinationRequestModel model);

		ApiPipelineStepDestinationResponseModel MapBOToModel(
			BOPipelineStepDestination boPipelineStepDestination);

		List<ApiPipelineStepDestinationResponseModel> MapBOToModel(
			List<BOPipelineStepDestination> bos);
	}
}

/*<Codenesium>
    <Hash>534826661ee6c4a5c13cec3e567a0fc1</Hash>
</Codenesium>*/