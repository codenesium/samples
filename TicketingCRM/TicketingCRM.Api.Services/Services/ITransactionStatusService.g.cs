using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface ITransactionStatusService
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
    <Hash>cfdc65eeed4a002ee00489dbaa876507</Hash>
</Codenesium>*/