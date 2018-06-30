using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiUserModelMapper
        {
                public virtual ApiUserResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRequestModel request)
                {
                        var response = new ApiUserResponseModel();
                        response.SetProperties(id,
                                               request.DisplayName,
                                               request.EmailAddress,
                                               request.ExternalId,
                                               request.ExternalIdentifiers,
                                               request.IdentificationToken,
                                               request.IsActive,
                                               request.IsService,
                                               request.JSON,
                                               request.Username);
                        return response;
                }

                public virtual ApiUserRequestModel MapResponseToRequest(
                        ApiUserResponseModel response)
                {
                        var request = new ApiUserRequestModel();
                        request.SetProperties(
                                response.DisplayName,
                                response.EmailAddress,
                                response.ExternalId,
                                response.ExternalIdentifiers,
                                response.IdentificationToken,
                                response.IsActive,
                                response.IsService,
                                response.JSON,
                                response.Username);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>b6c9a82ca8f95427e8a31fae3f7bc165</Hash>
</Codenesium>*/