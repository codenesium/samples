using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IBOLEventMapper
        {
                BOEvent MapModelToBO(
                        int id,
                        ApiEventRequestModel model);

                ApiEventResponseModel MapBOToModel(
                        BOEvent boEvent);

                List<ApiEventResponseModel> MapBOToModel(
                        List<BOEvent> items);
        }
}

/*<Codenesium>
    <Hash>0690ccb9b8d2c3d495aabcb99108dc17</Hash>
</Codenesium>*/