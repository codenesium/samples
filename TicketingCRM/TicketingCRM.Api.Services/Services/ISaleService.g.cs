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

                Task<List<ApiSaleResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSaleResponseModel>> GetTransactionId(int transactionId);

                Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b74c4c616ef9c845e21faedcede90df5</Hash>
</Codenesium>*/