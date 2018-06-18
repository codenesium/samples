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

                Task<List<ApiSaleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleResponseModel>> GetTransactionId(int transactionId);

                Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int saleId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c72a6ff95bac65ec258e5b385f5ff94c</Hash>
</Codenesium>*/