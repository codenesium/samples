using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTenantVariableModelMapper
        {
                ApiTenantVariableResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantVariableRequestModel request);

                ApiTenantVariableRequestModel MapResponseToRequest(
                        ApiTenantVariableResponseModel response);

                JsonPatchDocument<ApiTenantVariableRequestModel> CreatePatch(ApiTenantVariableRequestModel model);
        }
}

/*<Codenesium>
    <Hash>7eda205bfb756341ec2aa78f3ff35ee5</Hash>
</Codenesium>*/