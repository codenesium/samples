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

                Task<List<ApiSaleTicketsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiSaleTicketsResponseModel>> GetTicketId(int ticketId);
        }
}

/*<Codenesium>
    <Hash>d2a2da581be702f7a70f72ab1aa94605</Hash>
</Codenesium>*/