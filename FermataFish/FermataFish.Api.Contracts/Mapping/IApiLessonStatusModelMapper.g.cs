using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonStatusModelMapper
        {
                ApiLessonStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonStatusRequestModel request);

                ApiLessonStatusRequestModel MapResponseToRequest(
                        ApiLessonStatusResponseModel response);

                JsonPatchDocument<ApiLessonStatusRequestModel> CreatePatch(ApiLessonStatusRequestModel model);
        }
}

/*<Codenesium>
    <Hash>44f831ee0e36b0589f44fce4ccb0e13f</Hash>
</Codenesium>*/