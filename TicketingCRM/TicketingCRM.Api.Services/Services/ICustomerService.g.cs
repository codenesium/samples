using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICustomerService
	{
		Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model);

		Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(int id,
		                                                             ApiCustomerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCustomerServerResponseModel> Get(int id);

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e25d0c065ec46973da0e7ccc834aaea3</Hash>
</Codenesium>*/