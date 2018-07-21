using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiAdminModelMapper
        {
                ApiAdminResponseModel MapRequestToResponse(
                        int id,
                        ApiAdminRequestModel request);

                ApiAdminRequestModel MapResponseToRequest(
                        ApiAdminResponseModel response);

                JsonPatchDocument<ApiAdminRequestModel> CreatePatch(ApiAdminRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7e582b333cd5297632f8594ec52413b2</Hash>
</Codenesium>*/