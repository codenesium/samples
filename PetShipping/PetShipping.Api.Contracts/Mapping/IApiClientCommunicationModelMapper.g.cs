using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiClientCommunicationModelMapper
        {
                ApiClientCommunicationResponseModel MapRequestToResponse(
                        int id,
                        ApiClientCommunicationRequestModel request);

                ApiClientCommunicationRequestModel MapResponseToRequest(
                        ApiClientCommunicationResponseModel response);

                JsonPatchDocument<ApiClientCommunicationRequestModel> CreatePatch(ApiClientCommunicationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>f963a7d9509cea74f94cdab734584006</Hash>
</Codenesium>*/