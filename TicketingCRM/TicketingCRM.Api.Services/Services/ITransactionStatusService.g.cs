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

                Task<List<ApiTransactionStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6779dec1e21e3da29a2783f34f7f1779</Hash>
</Codenesium>*/