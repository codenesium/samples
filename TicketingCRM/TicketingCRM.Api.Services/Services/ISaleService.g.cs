using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ISaleService
        {
                Task<CreateResponse<ApiSaleResponseModel>> Create(
                        ApiSaleRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSaleRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSaleResponseModel> Get(int id);

                Task<List<ApiSaleResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiSaleResponseModel>> GetTransactionId(int transactionId);
        }
}

/*<Codenesium>
    <Hash>e9f0297da3db8d9ab5fb96a67de09bd2</Hash>
</Codenesium>*/