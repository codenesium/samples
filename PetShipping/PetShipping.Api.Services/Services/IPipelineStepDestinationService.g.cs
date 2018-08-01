using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IPipelineStepDestinationService
	{
		Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
			ApiPipelineStepDestinationRequestModel model);

		Task<UpdateResponse<ApiPipelineStepDestinationResponseModel>> Update(int id,
		                                                                      ApiPipelineStepDestinationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepDestinationResponseModel> Get(int id);

		Task<List<ApiPipelineStepDestinationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9f4ae24bb0a015c849f45468ed14c01a</Hash>
</Codenesium>*/