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

                Task<ActionResponse> Update(int id,
                                            ApiTransactionRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTransactionResponseModel> Get(int id);

                Task<List<ApiTransactionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTransactionResponseModel>> GetTransactionStatusId(int transactionStatusId);

                Task<List<ApiSaleResponseModel>> Sales(int transactionId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>62f8b60de1c6d10c80b61f4cd0ff7070</Hash>
</Codenesium>*/