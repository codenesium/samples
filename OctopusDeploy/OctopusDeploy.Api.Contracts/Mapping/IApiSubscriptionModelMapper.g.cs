using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiSubscriptionModelMapper
        {
                ApiSubscriptionResponseModel MapRequestToResponse(
                        string id,
                        ApiSubscriptionRequestModel request);

                ApiSubscriptionRequestModel MapResponseToRequest(
                        ApiSubscriptionResponseModel response);

                JsonPatchDocument<ApiSubscriptionRequestModel> CreatePatch(ApiSubscriptionRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a3a6a6a9662e52f008748dcc87fd842d</Hash>
</Codenesium>*/