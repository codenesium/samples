using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface ITicketService
        {
                Task<CreateResponse<ApiTicketResponseModel>> Create(
                        ApiTicketRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiTicketRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiTicketResponseModel> Get(int id);

                Task<List<ApiTicketResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiTicketResponseModel>> GetTicketStatusId(int ticketStatusId);

                Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>67004ac08197f8ec412d7b230c7e7054</Hash>
</Codenesium>*/