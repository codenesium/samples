using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectModelMapper
        {
                ApiProjectResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectRequestModel request);

                ApiProjectRequestModel MapResponseToRequest(
                        ApiProjectResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9d4546ebc8d4649c86d03c819d5afa2c</Hash>
</Codenesium>*/