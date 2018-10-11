using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IHandlerService
	{
		Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model);

		Task<UpdateResponse<ApiHandlerResponseModel>> Update(int id,
		                                                      ApiHandlerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiHandlerResponseModel> Get(int id);

		Task<List<ApiHandlerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiAirTransportResponseModel>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiHandlerResponseModel>> ByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6f409e2023947b4b6285f36c2d5fbd08</Hash>
</Codenesium>*/