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

		Task<UpdateResponse<ApiAirTransportServerResponseModel>> Update(int id,
		                                                                 ApiAirTransportServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAirTransportServerResponseModel> Get(int id);

		Task<List<ApiAirTransportServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>f7e14e22f876f5cbea15d53c1f06cdb0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/