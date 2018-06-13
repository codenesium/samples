using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ITransactionStatusService
        {
                Task<CreateResponse<ApiTransactionStatusResponseModel>> Create(
                        ApiTransactionStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTransactionStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTransactionStatusResponseModel> Get(int id);

                Task<List<ApiTransactionStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b65a75f88f85442b5ce363c4ec08d771</Hash>
</Codenesium>*/