using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface ISaleTicketsService
	{
		Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
			ApiSaleTicketsRequestModel model);

		Task<UpdateResponse<ApiSaleTicketsResponseModel>> Update(int id,
		                                                          ApiSaleTicketsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleTicketsResponseModel> Get(int id);

		Task<List<ApiSaleTicketsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketsResponseModel>> ByTicketId(int ticketId);
	}
}

/*<Codenesium>
    <Hash>c1e8d0b45904d0eea6ea8ea137658255</Hash>
</Codenesium>*/