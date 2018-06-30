using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonXStudentModelMapper
        {
                ApiLessonXStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXStudentRequestModel request);

                ApiLessonXStudentRequestModel MapResponseToRequest(
                        ApiLessonXStudentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>9e37c7a089dcde944d5da3d9e86b0d0f</Hash>
</Codenesium>*/