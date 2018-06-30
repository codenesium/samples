using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTagSetModelMapper
        {
                ApiTagSetResponseModel MapRequestToResponse(
                        string id,
                        ApiTagSetRequestModel request);

                ApiTagSetRequestModel MapResponseToRequest(
                        ApiTagSetResponseModel response);
        }
}

/*<Codenesium>
    <Hash>ed3dfad310f10d8a5fa845e7da64c9f4</Hash>
</Codenesium>*/