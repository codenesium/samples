using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiCommunityActionTemplateModelMapper
        {
                ApiCommunityActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiCommunityActionTemplateRequestModel request);

                ApiCommunityActionTemplateRequestModel MapResponseToRequest(
                        ApiCommunityActionTemplateResponseModel response);

                JsonPatchDocument<ApiCommunityActionTemplateRequestModel> CreatePatch(ApiCommunityActionTemplateRequestModel model);
        }
}

/*<Codenesium>
    <Hash>955956ad4babee88d22b888e31f197a9</Hash>
</Codenesium>*/