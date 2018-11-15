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

		Task<List<ApiOtherTransportServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1836c06ed5cabbd6727bf2623775ac6d</Hash>
</Codenesium>*/