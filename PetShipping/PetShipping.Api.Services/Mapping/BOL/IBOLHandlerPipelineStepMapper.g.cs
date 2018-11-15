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
			ApiHandlerPipelineStepServerRequestModel model);

		ApiHandlerPipelineStepServerResponseModel MapBOToModel(
			BOHandlerPipelineStep boHandlerPipelineStep);

		List<ApiHandlerPipelineStepServerResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>bc075d07d2f2c2a2cca8f12fb672ebb7</Hash>
</Codenesium>*/