using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiApiKeyModelMapper
        {
                ApiApiKeyResponseModel MapRequestToResponse(
                        string id,
                        ApiApiKeyRequestModel request);

                ApiApiKeyRequestModel MapResponseToRequest(
                        ApiApiKeyResponseModel response);

                JsonPatchDocument<ApiApiKeyRequestModel> CreatePatch(ApiApiKeyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>05c7000330fb52325de587757485477b</Hash>
</Codenesium>*/