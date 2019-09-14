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

		Task<List<ApiSaleServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleServerResponseModel>> ByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleTicketsServerResponseModel>> SaleTicketsBySaleId(int saleId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7b739f25b8e8cfcbde7bb8cc5d45544a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/