using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonModelMapper
        {
                ApiLessonResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonRequestModel request);

                ApiLessonRequestModel MapResponseToRequest(
                        ApiLessonResponseModel response);

                JsonPatchDocument<ApiLessonRequestModel> CreatePatch(ApiLessonRequestModel model);
        }
}

/*<Codenesium>
    <Hash>45cd01e199bf143983739c34e383d469</Hash>
</Codenesium>*/