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

                Task<List<ApiTicketStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTicketResponseModel>> Tickets(int ticketStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f9ffc732450dd044b40ab3c5b23030d7</Hash>
</Codenesium>*/