using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiProjectGroupModelMapper
        {
                ApiProjectGroupResponseModel MapRequestToResponse(
                        string id,
                        ApiProjectGroupRequestModel request);

                ApiProjectGroupRequestModel MapResponseToRequest(
                        ApiProjectGroupResponseModel response);

                JsonPatchDocument<ApiProjectGroupRequestModel> CreatePatch(ApiProjectGroupRequestModel model);
        }
}

/*<Codenesium>
    <Hash>748cd6e5b3e79a1aaced0b5964af16e0</Hash>
</Codenesium>*/