using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiActionTemplateVersionModelMapper
        {
                ApiActionTemplateVersionResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateVersionRequestModel request);

                ApiActionTemplateVersionRequestModel MapResponseToRequest(
                        ApiActionTemplateVersionResponseModel response);
        }
}

/*<Codenesium>
    <Hash>5f74646ee84bf4391466705c5d69e265</Hash>
</Codenesium>*/