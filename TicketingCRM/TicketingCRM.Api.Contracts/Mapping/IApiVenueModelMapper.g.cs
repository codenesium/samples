using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
        public interface IApiVenueModelMapper
        {
                ApiVenueResponseModel MapRequestToResponse(
                        int id,
                        ApiVenueRequestModel request);

                ApiVenueRequestModel MapResponseToRequest(
                        ApiVenueResponseModel response);

                JsonPatchDocument<ApiVenueRequestModel> CreatePatch(ApiVenueRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d6bcec969fe89a7a45374cf4700546a4</Hash>
</Codenesium>*/