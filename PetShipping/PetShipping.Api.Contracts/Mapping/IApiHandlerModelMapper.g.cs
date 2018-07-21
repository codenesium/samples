using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiHandlerModelMapper
        {
                ApiHandlerResponseModel MapRequestToResponse(
                        int id,
                        ApiHandlerRequestModel request);

                ApiHandlerRequestModel MapResponseToRequest(
                        ApiHandlerResponseModel response);

                JsonPatchDocument<ApiHandlerRequestModel> CreatePatch(ApiHandlerRequestModel model);
        }
}

/*<Codenesium>
    <Hash>8f9c522986787dab6e497d60e6230551</Hash>
</Codenesium>*/