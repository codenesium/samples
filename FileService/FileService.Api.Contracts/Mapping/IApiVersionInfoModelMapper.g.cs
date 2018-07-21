using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
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
    <Hash>0483fcffe4cb5a7ea357756bb97d6f24</Hash>
</Codenesium>*/