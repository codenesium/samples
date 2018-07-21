using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiVersionInfoModelMapper
        {
                ApiVersionInfoResponseModel MapRequestToResponse(
                        long version,
                        ApiVersionInfoRequestModel request);

                ApiVersionInfoRequestModel MapResponseToRequest(
                        ApiVersionInfoResponseModel response);

                JsonPatchDocument<ApiVersionInfoRequestModel> CreatePatch(ApiVersionInfoRequestModel model);
        }
}

/*<Codenesium>
    <Hash>5b20e4203dc7a746a3b5483b157f7e3d</Hash>
</Codenesium>*/