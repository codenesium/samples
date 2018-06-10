using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<ApiTransactionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiTransactionResponseModel>> GetTransactionStatusId(int transactionStatusId);
        }
}

/*<Codenesium>
    <Hash>1a26b5c587dac30c45142389ac6e09f8</Hash>
</Codenesium>*/