using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
        public interface IApiRowVersionCheckModelMapper
        {
                ApiRowVersionCheckResponseModel MapRequestToResponse(
                        int id,
                        ApiRowVersionCheckRequestModel request);

                ApiRowVersionCheckRequestModel MapResponseToRequest(
                        ApiRowVersionCheckResponseModel response);

                JsonPatchDocument<ApiRowVersionCheckRequestModel> CreatePatch(ApiRowVersionCheckRequestModel model);
        }
}

/*<Codenesium>
    <Hash>e075ef6454e5910948c2344644856867</Hash>
</Codenesium>*/