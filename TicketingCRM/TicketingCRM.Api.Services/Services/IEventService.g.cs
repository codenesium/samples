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

                Task<UpdateResponse<ApiEventResponseModel>> Update(int id,
                                                                    ApiEventRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiEventResponseModel> Get(int id);

                Task<List<ApiEventResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEventResponseModel>> ByCityId(int cityId);
        }
}

/*<Codenesium>
    <Hash>dd5213bd027b5b7153af5e1602caf203</Hash>
</Codenesium>*/