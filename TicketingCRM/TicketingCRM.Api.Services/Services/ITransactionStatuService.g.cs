using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ITransactionStatuService
	{
		Task<CreateResponse<ApiTransactionStatuResponseModel>> Create(
			ApiTransactionStatuRequestModel model);

		Task<UpdateResponse<ApiTransactionStatuResponseModel>> Update(int id,
		                                                               ApiTransactionStatuRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTransactionStatuResponseModel> Get(int id);

		Task<List<ApiTransactionStatuResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ee6378176ff0f131ff5fbbca48035743</Hash>
</Codenesium>*/