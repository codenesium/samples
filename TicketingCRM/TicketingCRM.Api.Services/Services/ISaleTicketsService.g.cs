using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ISaleTicketsService
        {
                Task<CreateResponse<ApiSaleTicketsResponseModel>> Create(
                        ApiSaleTicketsRequestModel model);

                Task<UpdateResponse<ApiSaleTicketsResponseModel>> Update(int id,
                                                                          ApiSaleTicketsRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSaleTicketsResponseModel> Get(int id);

                Task<List<ApiSaleTicketsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleTicketsResponseModel>> ByTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>c9a6ac0fad55e76ed5ad03b33e2ec7fd</Hash>
</Codenesium>*/