using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonXStudentModelMapper
        {
                public virtual ApiLessonXStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXStudentRequestModel request)
                {
                        var response = new ApiLessonXStudentResponseModel();
                        response.SetProperties(id,
                                               request.LessonId,
                                               request.StudentId);
                        return response;
                }

                public virtual ApiLessonXStudentRequestModel MapResponseToRequest(
                        ApiLessonXStudentResponseModel response)
                {
                        var request = new ApiLessonXStudentRequestModel();
                        request.SetProperties(
                                response.LessonId,
                                response.StudentId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>bafe319220a0e884bf86c2f36a7ce720</Hash>
</Codenesium>*/