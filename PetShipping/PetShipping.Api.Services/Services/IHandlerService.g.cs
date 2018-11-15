using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IHandlerService
	{
		Task<CreateResponse<ApiHandlerServerResponseModel>> Create(
			ApiHandlerServerRequestModel model);

		Task<UpdateResponse<ApiHandlerServerResponseModel>> Update(int id,
		                                                            ApiHandlerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerServerResponseModel> Get(int id);

		Task<List<ApiHandlerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAirTransportServerResponseModel>> AirTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiHandlerPipelineStepServerResponseModel>> HandlerPipelineStepsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOtherTransportServerResponseModel>> OtherTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0dc19d4563afd0fce0ab2af196d6ddac</Hash>
</Codenesium>*/