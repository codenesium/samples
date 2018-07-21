using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiMachineModelMapper
        {
                ApiMachineResponseModel MapRequestToResponse(
                        string id,
                        ApiMachineRequestModel request);

                ApiMachineRequestModel MapResponseToRequest(
                        ApiMachineResponseModel response);

                JsonPatchDocument<ApiMachineRequestModel> CreatePatch(ApiMachineRequestModel model);
        }
}

/*<Codenesium>
    <Hash>a0da9e9c0eec252a0e9d1813ef2d5a3c</Hash>
</Codenesium>*/