using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketStatuService
	{
		Task<CreateResponse<ApiTicketStatuResponseModel>> Create(
			ApiTicketStatuRequestModel model);

		Task<UpdateResponse<ApiTicketStatuResponseModel>> Update(int id,
		                                                          ApiTicketStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketStatuResponseModel> Get(int id);

		Task<List<ApiTicketStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>14e8a22efe69d7b0ad1f0cb277159553</Hash>
</Codenesium>*/