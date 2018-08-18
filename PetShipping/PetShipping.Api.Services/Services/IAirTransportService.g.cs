using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IAirTransportService
	{
		Task<CreateResponse<ApiAirTransportResponseModel>> Create(
			ApiAirTransportRequestModel model);

		Task<UpdateResponse<ApiAirTransportResponseModel>> Update(int airlineId,
		                                                           ApiAirTransportRequestModel model);

		Task<ActionResponse> Delete(int airlineId);

		Task<ApiAirTransportResponseModel> Get(int airlineId);

		Task<List<ApiAirTransportResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1077bbf2a1555e7b7eb88c1080882d13</Hash>
</Codenesium>*/