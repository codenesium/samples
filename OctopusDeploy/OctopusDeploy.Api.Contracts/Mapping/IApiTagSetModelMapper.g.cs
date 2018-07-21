using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public interface IApiTagSetModelMapper
        {
                ApiTagSetResponseModel MapRequestToResponse(
                        string id,
                        ApiTagSetRequestModel request);

                ApiTagSetRequestModel MapResponseToRequest(
                        ApiTagSetResponseModel response);

                JsonPatchDocument<ApiTagSetRequestModel> CreatePatch(ApiTagSetRequestModel model);
        }
}

/*<Codenesium>
    <Hash>cf568c1af64684449cdbbac16a336ed8</Hash>
</Codenesium>*/