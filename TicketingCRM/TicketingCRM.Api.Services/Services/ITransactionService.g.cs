using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ITransactionService
        {
                Task<CreateResponse<ApiTransactionResponseModel>> Create(
                        ApiTransactionRequestModel model);

                Task<UpdateResponse<ApiTransactionResponseModel>> Update(int id,
                                                                          ApiTransactionRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTransactionResponseModel> Get(int id);

                Task<List<ApiTransactionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTransactionResponseModel>> ByTransactionStatusId(int transactionStatusId);

                Task<List<ApiSaleResponseModel>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c053f58f9614460a8343accd684c7382</Hash>
</Codenesium>*/