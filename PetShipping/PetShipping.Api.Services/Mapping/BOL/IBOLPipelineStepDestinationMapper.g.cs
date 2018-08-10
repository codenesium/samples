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
    <Hash>51bf7b5872e25bc3924dd3ea3d1da170</Hash>
</Codenesium>*/