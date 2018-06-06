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
			List<BOHandlerPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>22d3d81dd18fc759ad7387390449e602</Hash>
</Codenesium>*/