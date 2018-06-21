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

                Task<ActionResponse> Update(int id,
                                            ApiTransactionStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTransactionStatusResponseModel> Get(int id);

                Task<List<ApiTransactionStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTransactionResponseModel>> Transactions(int transactionStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b575c152575331de4c7370a52e770c24</Hash>
</Codenesium>*/