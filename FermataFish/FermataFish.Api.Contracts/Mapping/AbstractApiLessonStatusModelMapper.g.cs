using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiLessonStatusModelMapper
        {
                public virtual ApiLessonStatusResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonStatusRequestModel request)
                {
                        var response = new ApiLessonStatusResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiLessonStatusRequestModel MapResponseToRequest(
                        ApiLessonStatusResponseModel response)
                {
                        var request = new ApiLessonStatusRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>4054b15d81f97530cb36bb60dd7d55d0</Hash>
</Codenesium>*/