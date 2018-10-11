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

		Task<List<ApiSaleResponseModel>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>02af6b97093d4f6a4ad0a8d636049463</Hash>
</Codenesium>*/