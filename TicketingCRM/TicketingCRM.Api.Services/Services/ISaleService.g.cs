using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ISaleService
	{
		Task<CreateResponse<ApiSaleServerResponseModel>> Create(
			ApiSaleServerRequestModel model);

		Task<UpdateResponse<ApiSaleServerResponseModel>> Update(int id,
		                                                         ApiSaleServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSaleServerResponseModel> Get(int id);

		Task<List<ApiSaleServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> BySaleId(int saleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>023a6fb8722083e1c85e2ca3dce51830</Hash>
</Codenesium>*/