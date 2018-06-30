using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

                Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventResponseModel>> ByCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>7bb7dc331cd000201aa19d42a5704939</Hash>
</Codenesium>*/