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

		Task<List<ApiTicketResponseModel>> TicketsByTicketStatusId(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a0ad4603b1a59cfb37dea1732a72c0e4</Hash>
</Codenesium>*/