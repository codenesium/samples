using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITransactionStatusService
	{
		Task<CreateResponse<ApiTransactionStatusServerResponseModel>> Create(
			ApiTransactionStatusServerRequestModel model);

		Task<UpdateResponse<ApiTransactionStatusServerResponseModel>> Update(int id,
		                                                                      ApiTransactionStatusServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTransactionStatusServerResponseModel> Get(int id);

		Task<List<ApiTransactionStatusServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTransactionServerResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e95e1f702c00098c276aeb56021ab9a8</Hash>
</Codenesium>*/