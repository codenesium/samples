using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IHandlerPipelineStepService
	{
		Task<CreateResponse<ApiHandlerPipelineStepServerResponseModel>> Create(
			ApiHandlerPipelineStepServerRequestModel model);

		Task<UpdateResponse<ApiHandlerPipelineStepServerResponseModel>> Update(int id,
		                                                                        ApiHandlerPipelineStepServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerPipelineStepServerResponseModel> Get(int id);

		Task<List<ApiHandlerPipelineStepServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>f44f79ad4b9604dc747a032d2f09f72d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/