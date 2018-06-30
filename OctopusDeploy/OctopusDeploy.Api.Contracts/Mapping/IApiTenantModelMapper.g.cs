using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTenantModelMapper
        {
                ApiTenantResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantRequestModel request);

                ApiTenantRequestModel MapResponseToRequest(
                        ApiTenantResponseModel response);
        }
}

/*<Codenesium>
    <Hash>b73e01e3144939b7f083de82b0c5ad3f</Hash>
</Codenesium>*/