using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITransactionStatusService
	{
		Task<CreateResponse<ApiTransactionStatusResponseModel>> Create(
			ApiTransactionStatusRequestModel model);

		Task<UpdateResponse<ApiTransactionStatusResponseModel>> Update(int id,
		                                                                ApiTransactionStatusRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTransactionStatusResponseModel> Get(int id);

		Task<List<ApiTransactionStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>73cc23b7f51a69afde280d2bc4a22d0f</Hash>
</Codenesium>*/