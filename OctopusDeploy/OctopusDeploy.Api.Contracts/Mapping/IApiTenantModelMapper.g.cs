using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTenantModelMapper
        {
                ApiTenantResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantRequestModel request);

                ApiTenantRequestModel MapResponseToRequest(
                        ApiTenantResponseModel response);

                JsonPatchDocument<ApiTenantRequestModel> CreatePatch(ApiTenantRequestModel model);
        }
}

/*<Codenesium>
    <Hash>635c85c938bcc159fb700334d38bc1b0</Hash>
</Codenesium>*/