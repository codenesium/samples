using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALHandlerPipelineStepMapper
	{
		HandlerPipelineStep MapModelToEntity(
			int id,
			ApiHandlerPipelineStepServerRequestModel model);

		ApiHandlerPipelineStepServerResponseModel MapEntityToModel(
			HandlerPipelineStep item);

		List<ApiHandlerPipelineStepServerResponseModel> MapEntityToModel(
			List<HandlerPipelineStep> items);
	}
}

/*<Codenesium>
    <Hash>0a6cb14aa964921a095e87dd79504f57</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/