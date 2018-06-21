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

                Task<ActionResponse> Update(int id,
                                            ApiSaleTicketsRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSaleTicketsResponseModel> Get(int id);

                Task<List<ApiSaleTicketsResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleTicketsResponseModel>> GetTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>e795a6f0f1f03355d5b53b2644521454</Hash>
</Codenesium>*/