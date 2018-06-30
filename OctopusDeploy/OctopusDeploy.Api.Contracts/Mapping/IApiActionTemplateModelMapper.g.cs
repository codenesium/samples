using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiActionTemplateModelMapper
        {
                ApiActionTemplateResponseModel MapRequestToResponse(
                        string id,
                        ApiActionTemplateRequestModel request);

                ApiActionTemplateRequestModel MapResponseToRequest(
                        ApiActionTemplateResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0ebfa55a0ddecca1b78aefae3becf65a</Hash>
</Codenesium>*/