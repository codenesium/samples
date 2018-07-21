using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiTicketStatusModelMapper
        {
                ApiTicketStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiTicketStatusRequestModel request);

                ApiTicketStatusRequestModel MapResponseToRequest(
                        ApiTicketStatusResponseModel response);

                JsonPatchDocument<ApiTicketStatusRequestModel> CreatePatch(ApiTicketStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>dd007fa59de3661d0899a3a3f26e6294</Hash>
</Codenesium>*/