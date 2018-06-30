using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiFeedModelMapper
        {
                ApiFeedResponseModel MapRequestToResponse(
                        string id,
                        ApiFeedRequestModel request);

                ApiFeedRequestModel MapResponseToRequest(
                        ApiFeedResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e996b0a5c5638f93f481cc68d842f95b</Hash>
</Codenesium>*/