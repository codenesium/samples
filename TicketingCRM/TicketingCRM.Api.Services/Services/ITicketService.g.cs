using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface ITicketService
	{
		Task<CreateResponse<ApiTicketResponseModel>> Create(
			ApiTicketRequestModel model);

		Task<UpdateResponse<ApiTicketResponseModel>> Update(int id,
		                                                     ApiTicketRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketResponseModel> Get(int id);

		Task<List<ApiTicketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketResponseModel>> ByTicketStatusId(int ticketStatusId);

		Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c791e73414f1b871124a8229463e644b</Hash>
</Codenesium>*/