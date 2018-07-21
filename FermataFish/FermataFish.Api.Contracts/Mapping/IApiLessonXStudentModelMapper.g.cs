using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiLessonXStudentModelMapper
        {
                ApiLessonXStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiLessonXStudentRequestModel request);

                ApiLessonXStudentRequestModel MapResponseToRequest(
                        ApiLessonXStudentResponseModel response);

                JsonPatchDocument<ApiLessonXStudentRequestModel> CreatePatch(ApiLessonXStudentRequestModel model);
        }
}

/*<Codenesium>
    <Hash>304364fc486a99391f5e01f4be8f61c6</Hash>
</Codenesium>*/