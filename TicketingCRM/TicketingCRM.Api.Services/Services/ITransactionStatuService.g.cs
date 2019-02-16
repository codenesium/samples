using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITransactionStatuService
	{
		Task<CreateResponse<ApiTransactionStatuServerResponseModel>> Create(
			ApiTransactionStatuServerRequestModel model);

		Task<UpdateResponse<ApiTransactionStatuServerResponseModel>> Update(int id,
		                                                                     ApiTransactionStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTransactionStatuServerResponseModel> Get(int id);

		Task<List<ApiTransactionStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTransactionServerResponseModel>> TransactionsByTransactionStatusId(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5cb32b0268b178190fc051216a918102</Hash>
</Codenesium>*/