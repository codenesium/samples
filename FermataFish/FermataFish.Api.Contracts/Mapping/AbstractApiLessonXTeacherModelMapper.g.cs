using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonXTeacherModelMapper
        {
                public virtual ApiLessonXTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXTeacherRequestModel request)
                {
                        var response = new ApiLessonXTeacherResponseModel();
                        response.SetProperties(id,
                                               request.LessonId,
                                               request.StudentId);
                        return response;
                }

                public virtual ApiLessonXTeacherRequestModel MapResponseToRequest(
                        ApiLessonXTeacherResponseModel response)
                {
                        var request = new ApiLessonXTeacherRequestModel();
                        request.SetProperties(
                                response.LessonId,
                                response.StudentId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>9b86757bec6d9e860c1fe12abcb2de34</Hash>
</Codenesium>*/