using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonModelMapper
        {
                ApiLessonResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonRequestModel request);

                ApiLessonRequestModel MapResponseToRequest(
                        ApiLessonResponseModel response);
        }
}

/*<Codenesium>
    <Hash>24aaf8f57142be6e1c17412c73f86aed</Hash>
</Codenesium>*/