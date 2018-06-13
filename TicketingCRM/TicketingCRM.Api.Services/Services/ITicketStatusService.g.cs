using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ITicketStatusService
        {
                Task<CreateResponse<ApiTicketStatusResponseModel>> Create(
                        ApiTicketStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTicketStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTicketStatusResponseModel> Get(int id);

                Task<List<ApiTicketStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e9027e08e8f29a5b38f5268c6aa34d8f</Hash>
</Codenesium>*/