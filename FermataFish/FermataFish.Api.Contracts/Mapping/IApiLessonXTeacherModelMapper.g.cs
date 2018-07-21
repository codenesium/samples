using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonXTeacherModelMapper
        {
                ApiLessonXTeacherResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXTeacherRequestModel request);

                ApiLessonXTeacherRequestModel MapResponseToRequest(
                        ApiLessonXTeacherResponseModel response);

                JsonPatchDocument<ApiLessonXTeacherRequestModel> CreatePatch(ApiLessonXTeacherRequestModel model);
        }
}

/*<Codenesium>
    <Hash>d57e81973f5ed8c1abf33a1a2981aa00</Hash>
</Codenesium>*/