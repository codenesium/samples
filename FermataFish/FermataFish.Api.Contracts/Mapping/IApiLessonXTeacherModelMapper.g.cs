using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonXTeacherModelMapper
        {
                ApiLessonXTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXTeacherRequestModel request);

                ApiLessonXTeacherRequestModel MapResponseToRequest(
                        ApiLessonXTeacherResponseModel response);
        }
}

/*<Codenesium>
    <Hash>a65d32ca2197d108e3209b4d1fd21edc</Hash>
</Codenesium>*/