using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IHandlerService
	{
		Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model);

		Task<UpdateResponse<ApiHandlerResponseModel>> Update(int id,
		                                                      ApiHandlerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerResponseModel> Get(int id);

		Task<List<ApiHandlerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOtherTransportResponseModel>> OtherTransports(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b1714bdcefa7f6c7a6e45f7cb8ebc257</Hash>
</Codenesium>*/