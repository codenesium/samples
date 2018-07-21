using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Contracts
{
        public interface IApiFileModelMapper
        {
                ApiFileResponseModel MapRequestToResponse(
                        int id,
                        ApiFileRequestModel request);

                ApiFileRequestModel MapResponseToRequest(
                        ApiFileResponseModel response);

                JsonPatchDocument<ApiFileRequestModel> CreatePatch(ApiFileRequestModel model);
        }
}

/*<Codenesium>
    <Hash>b3fe96456d535c5e9af3f4c95d13590f</Hash>
</Codenesium>*/