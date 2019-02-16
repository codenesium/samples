using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IOtherTransportService
	{
		Task<CreateResponse<ApiOtherTransportServerResponseModel>> Create(
			ApiOtherTransportServerRequestModel model);

		Task<UpdateResponse<ApiOtherTransportServerResponseModel>> Update(int id,
		                                                                   ApiOtherTransportServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOtherTransportServerResponseModel> Get(int id);

		Task<List<ApiOtherTransportServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>33b656b6b6b8963bca7a7a780c03937d</Hash>
</Codenesium>*/