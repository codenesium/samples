using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiKeyAllocationModelMapper
        {
                ApiKeyAllocationResponseModel MapRequestToResponse(
                        string collectionName,
                        ApiKeyAllocationRequestModel request);

                ApiKeyAllocationRequestModel MapResponseToRequest(
                        ApiKeyAllocationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>0c7e8b9b723e3664804af587071c02dd</Hash>
</Codenesium>*/