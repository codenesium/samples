using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IAirTransportService
	{
		Task<CreateResponse<ApiAirTransportServerResponseModel>> Create(
			ApiAirTransportServerRequestModel model);

		Task<UpdateResponse<ApiAirTransportServerResponseModel>> Update(int airlineId,
		                                                                 ApiAirTransportServerRequestModel model);

		Task<ActionResponse> Delete(int airlineId);

		Task<ApiAirTransportServerResponseModel> Get(int airlineId);

		Task<List<ApiAirTransportServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>9d844c05514af173da9427fd56908fad</Hash>
</Codenesium>*/