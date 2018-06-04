using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLHandlerPipelineStepMapper
	{
		BOHandlerPipelineStep MapModelToBO(
			int id,
			ApiHandlerPipelineStepRequestModel model);

		ApiHandlerPipelineStepResponseModel MapBOToModel(
			BOHandlerPipelineStep boHandlerPipelineStep);

		List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
			List<BOHandlerPipelineStep> bos);
	}
}

/*<Codenesium>
    <Hash>515d6df6ce0f8d9eaad5b51cbfc7e5e8</Hash>
</Codenesium>*/