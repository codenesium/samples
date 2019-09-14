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

		Task<List<ApiPipelineStepDestinationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>c37865fb2f4a44c4c74ff087da2c1409</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/