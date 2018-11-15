using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITicketService
	{
		Task<CreateResponse<ApiTicketServerResponseModel>> Create(
			ApiTicketServerRequestModel model);

		Task<UpdateResponse<ApiTicketServerResponseModel>> Update(int id,
		                                                           ApiTicketServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTicketServerResponseModel> Get(int id);

		Task<List<ApiTicketServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTicketServerResponseModel>> ByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dafae5407d4743934289481fc21969bf</Hash>
</Codenesium>*/