using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IDestinationService
	{
		Task<CreateResponse<ApiDestinationServerResponseModel>> Create(
			ApiDestinationServerRequestModel model);

		Task<UpdateResponse<ApiDestinationServerResponseModel>> Update(int id,
		                                                                ApiDestinationServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDestinationServerResponseModel> Get(int id);

		Task<List<ApiDestinationServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ef60aba3a4d8836641903c7ad1e2668a</Hash>
</Codenesium>*/