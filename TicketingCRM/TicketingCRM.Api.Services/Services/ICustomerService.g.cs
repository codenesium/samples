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

		Task<List<ApiCustomerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>3435e9bf1db7c3c05675b2afb95dcdac</Hash>
</Codenesium>*/