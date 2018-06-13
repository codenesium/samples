using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IEventService
        {
                Task<CreateResponse<ApiEventResponseModel>> Create(
                        ApiEventRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiEventRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiEventResponseModel> Get(int id);

                Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiEventResponseModel>> GetCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>cd0676e3d6dc2543ac16605abed16c5e</Hash>
</Codenesium>*/