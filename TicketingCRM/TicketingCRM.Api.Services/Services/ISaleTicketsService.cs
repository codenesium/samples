using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleTicketsService
	{
		Task<CreateResponse<ApiSaleTicketsServerResponseModel>> Create(
			ApiSaleTicketsServerRequestModel model);

		Task<UpdateResponse<ApiSaleTicketsServerResponseModel>> Update(int id,
		                                                                ApiSaleTicketsServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleTicketsServerResponseModel> Get(int id);

		Task<List<ApiSaleTicketsServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleTicketsServerResponseModel>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0cf9259c235d4d4c9460a0dfcbdcf329</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/