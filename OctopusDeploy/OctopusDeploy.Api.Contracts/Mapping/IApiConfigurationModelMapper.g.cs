using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiConfigurationModelMapper
        {
                ApiConfigurationResponseModel MapRequestToResponse(
                        string id,
                        ApiConfigurationRequestModel request);

                ApiConfigurationRequestModel MapResponseToRequest(
                        ApiConfigurationResponseModel response);

                JsonPatchDocument<ApiConfigurationRequestModel> CreatePatch(ApiConfigurationRequestModel model);
        }
}

/*<Codenesium>
    <Hash>3519b02de95dbfc919f40421b099c592</Hash>
</Codenesium>*/