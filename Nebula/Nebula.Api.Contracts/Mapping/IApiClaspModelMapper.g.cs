using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Contracts
{
        public interface IApiClaspModelMapper
        {
                ApiClaspResponseModel MapRequestToResponse(
                        int id,
                        ApiClaspRequestModel request);

                ApiClaspRequestModel MapResponseToRequest(
                        ApiClaspResponseModel response);

                JsonPatchDocument<ApiClaspRequestModel> CreatePatch(ApiClaspRequestModel model);
        }
}

/*<Codenesium>
    <Hash>2caccb15f2c101fdf95af68199b059c9</Hash>
</Codenesium>*/