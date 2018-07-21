using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiChannelModelMapper
        {
                ApiChannelResponseModel MapRequestToResponse(
                        string id,
                        ApiChannelRequestModel request);

                ApiChannelRequestModel MapResponseToRequest(
                        ApiChannelResponseModel response);

                JsonPatchDocument<ApiChannelRequestModel> CreatePatch(ApiChannelRequestModel model);
        }
}

/*<Codenesium>
    <Hash>35d16c16201d41afc2a73cf4b948df25</Hash>
</Codenesium>*/