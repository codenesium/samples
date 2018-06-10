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

                Task<List<ApiTicketResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiTicketResponseModel>> GetTicketStatusId(int ticketStatusId);
        }
}

/*<Codenesium>
    <Hash>22a8103ea9daedeeb8971a550b3749e2</Hash>
</Codenesium>*/