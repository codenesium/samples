using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketStatuService
	{
		Task<CreateResponse<ApiTicketStatuServerResponseModel>> Create(
			ApiTicketStatuServerRequestModel model);

		Task<UpdateResponse<ApiTicketStatuServerResponseModel>> Update(int id,
		                                                                ApiTicketStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketStatuServerResponseModel> Get(int id);

		Task<List<ApiTicketStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketServerResponseModel>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c51c8243cc4dcb68c11b120e9d51344a</Hash>
</Codenesium>*/