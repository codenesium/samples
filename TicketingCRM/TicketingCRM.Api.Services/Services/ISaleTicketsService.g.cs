using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<ApiSaleTicketsResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiSaleTicketsResponseModel>> GetTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>3ff0feda0e6548737a584419546bb139</Hash>
</Codenesium>*/