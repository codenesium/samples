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
			List<BOPipelineStepDestination> items);
	}
}

/*<Codenesium>
    <Hash>9f8b130872e18b0741bd334585b6a7df</Hash>
</Codenesium>*/