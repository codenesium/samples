using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPipelineStepDestinationService
	{
		Task<CreateResponse<ApiPipelineStepDestinationServerResponseModel>> Create(
			ApiPipelineStepDestinationServerRequestModel model);

		Task<UpdateResponse<ApiPipelineStepDestinationServerResponseModel>> Update(int id,
		                                                                            ApiPipelineStepDestinationServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPipelineStepDestinationServerResponseModel> Get(int id);

		Task<List<ApiPipelineStepDestinationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>86b667910d2b95818a8336bfac60b537</Hash>
</Codenesium>*/