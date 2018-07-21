using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProxyModelMapper
        {
                ApiProxyResponseModel MapRequestToResponse(
                        string id,
                        ApiProxyRequestModel request);

                ApiProxyRequestModel MapResponseToRequest(
                        ApiProxyResponseModel response);

                JsonPatchDocument<ApiProxyRequestModel> CreatePatch(ApiProxyRequestModel model);
        }
}

/*<Codenesium>
    <Hash>4f275dc27aa8ecc774de99164499ccfd</Hash>
</Codenesium>*/