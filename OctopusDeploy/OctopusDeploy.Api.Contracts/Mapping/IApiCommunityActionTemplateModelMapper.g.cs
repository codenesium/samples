using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiCommunityActionTemplateModelMapper
        {
                ApiCommunityActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiCommunityActionTemplateRequestModel request);

                ApiCommunityActionTemplateRequestModel MapResponseToRequest(
                        ApiCommunityActionTemplateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>84d7c4b90ce0910912acf2969f3b2267</Hash>
</Codenesium>*/