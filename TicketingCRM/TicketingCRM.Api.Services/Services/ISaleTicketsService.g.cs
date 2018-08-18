using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleTicketsService
	{
		Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
			ApiSaleTicketsRequestModel model);

		Task<UpdateResponse<ApiSaleTicketsResponseModel>> Update(int id,
		                                                          ApiSaleTicketsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleTicketsResponseModel> Get(int id);

		Task<List<ApiSaleTicketsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketsResponseModel>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a9c2416a467bb06072a037ac812a3fd3</Hash>
</Codenesium>*/