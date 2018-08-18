using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLHandlerPipelineStepMapper
	{
		BOHandlerPipelineStep MapModelToBO(
			int id,
			ApiHandlerPipelineStepRequestModel model);

		ApiHandlerPipelineStepResponseModel MapBOToModel(
			BOHandlerPipelineStep boHandlerPipelineStep);

		List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>03a75aa99fdcc56b00cd6fac6d5c33e0</Hash>
</Codenesium>*/