using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepDestinationService
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
    <Hash>88da136ae77ff6dffaca4578af34fa97</Hash>
</Codenesium>*/