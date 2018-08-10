using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleService
	{
		Task<CreateResponse<ApiSaleResponseModel>> Create(
			ApiSaleRequestModel model);

		Task<UpdateResponse<ApiSaleResponseModel>> Update(int id,
		                                                   ApiSaleRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleResponseModel> Get(int id);

		Task<List<ApiSaleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> ByTransactionId(int transactionId);

		Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>24b8bc6d3e4de70298c28515d7f4bb47</Hash>
</Codenesium>*/