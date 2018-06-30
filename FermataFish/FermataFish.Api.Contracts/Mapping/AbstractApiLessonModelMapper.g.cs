using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonModelMapper
        {
                public virtual ApiLessonResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonRequestModel request)
                {
                        var response = new ApiLessonResponseModel();
                        response.SetProperties(id,
                                               request.ActualEndDate,
                                               request.ActualStartDate,
                                               request.BillAmount,
                                               request.LessonStatusId,
                                               request.ScheduledEndDate,
                                               request.ScheduledStartDate,
                                               request.StudentNotes,
                                               request.StudioId,
                                               request.TeacherNotes);
                        return response;
                }

                public virtual ApiLessonRequestModel MapResponseToRequest(
                        ApiLessonResponseModel response)
                {
                        var request = new ApiLessonRequestModel();
                        request.SetProperties(
                                response.ActualEndDate,
                                response.ActualStartDate,
                                response.BillAmount,
                                response.LessonStatusId,
                                response.ScheduledEndDate,
                                response.ScheduledStartDate,
                                response.StudentNotes,
                                response.StudioId,
                                response.TeacherNotes);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>7d32ce34cbf9ecd077fdbbdee5a3c256</Hash>
</Codenesium>*/