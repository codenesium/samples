using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleTicketService
	{
		Task<CreateResponse<ApiSaleTicketResponseModel>> Create(
			ApiSaleTicketRequestModel model);

		Task<UpdateResponse<ApiSaleTicketResponseModel>> Update(int id,
		                                                         ApiSaleTicketRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleTicketResponseModel> Get(int id);

		Task<List<ApiSaleTicketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketResponseModel>> ByTicketId(int ticketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>abf5b5275d090f193439d4ef2f21b3e6</Hash>
</Codenesium>*/