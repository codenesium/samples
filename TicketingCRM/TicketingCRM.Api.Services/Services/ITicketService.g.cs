using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<ApiTicketResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiTicketResponseModel>> GetTicketStatusId(int ticketStatusId);

                Task<List<ApiSaleTicketsResponseModel>> SaleTickets(int ticketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a82cbfecb49c5235cd621963d60039f9</Hash>
</Codenesium>*/