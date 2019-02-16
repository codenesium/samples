using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleTicketService
	{
		Task<CreateResponse<ApiSaleTicketServerResponseModel>> Create(
			ApiSaleTicketServerRequestModel model);

		Task<UpdateResponse<ApiSaleTicketServerResponseModel>> Update(int id,
		                                                               ApiSaleTicketServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleTicketServerResponseModel> Get(int id);

		Task<List<ApiSaleTicketServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleTicketServerResponseModel>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>88951947887000a90397162871361482</Hash>
</Codenesium>*/