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

                Task<List<ApiEventResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiEventResponseModel>> GetCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>7c839e1cb38a2c72fb189740c3545114</Hash>
</Codenesium>*/