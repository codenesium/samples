using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITransactionService
	{
		Task<CreateResponse<ApiTransactionServerResponseModel>> Create(
			ApiTransactionServerRequestModel model);

		Task<UpdateResponse<ApiTransactionServerResponseModel>> Update(int id,
		                                                                ApiTransactionServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTransactionServerResponseModel> Get(int id);

		Task<List<ApiTransactionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTransactionServerResponseModel>> ByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleServerResponseModel>> SalesByTransactionId(int transactionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>079c0ad5e7dfd638f1fc0a7f2a4b509c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/