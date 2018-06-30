using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiAccountModelMapper
        {
                public virtual ApiAccountResponseModel MapRequestToResponse(
                        string id,
                        ApiAccountRequestModel request)
                {
                        var response = new ApiAccountResponseModel();
                        response.SetProperties(id,
                                               request.AccountType,
                                               request.EnvironmentIds,
                                               request.JSON,
                                               request.Name,
                                               request.TenantIds,
                                               request.TenantTags);
                        return response;
                }

                public virtual ApiAccountRequestModel MapResponseToRequest(
                        ApiAccountResponseModel response)
                {
                        var request = new ApiAccountRequestModel();
                        request.SetProperties(
                                response.AccountType,
                                response.EnvironmentIds,
                                response.JSON,
                                response.Name,
                                response.TenantIds,
                                response.TenantTags);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>56a19e41e617dc6dcb4c56713601361b</Hash>
</Codenesium>*/