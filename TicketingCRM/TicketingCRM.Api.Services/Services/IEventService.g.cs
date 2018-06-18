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

                Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventResponseModel>> GetCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>5c6d041553ec14a704b951274c12ac77</Hash>
</Codenesium>*/