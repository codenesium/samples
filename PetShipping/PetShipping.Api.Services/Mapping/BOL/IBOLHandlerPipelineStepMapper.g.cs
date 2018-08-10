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
    <Hash>6be7983c51bc33e70ba0e2ee52bfa4ca</Hash>
</Codenesium>*/