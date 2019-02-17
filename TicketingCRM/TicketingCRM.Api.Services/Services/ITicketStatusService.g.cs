using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketStatusService
	{
		Task<CreateResponse<ApiTicketStatusServerResponseModel>> Create(
			ApiTicketStatusServerRequestModel model);

		Task<UpdateResponse<ApiTicketStatusServerResponseModel>> Update(int id,
		                                                                 ApiTicketStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketStatusServerResponseModel> Get(int id);

		Task<List<ApiTicketStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTicketServerResponseModel>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>66ab0248e12647e4122a6e7f7053cc7e</Hash>
</Codenesium>*/