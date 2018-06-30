using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonStatusModelMapper
        {
                ApiLessonStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonStatusRequestModel request);

                ApiLessonStatusRequestModel MapResponseToRequest(
                        ApiLessonStatusResponseModel response);
        }
}

/*<Codenesium>
    <Hash>78bf0b54abcc28739f0da71642965f6d</Hash>
</Codenesium>*/