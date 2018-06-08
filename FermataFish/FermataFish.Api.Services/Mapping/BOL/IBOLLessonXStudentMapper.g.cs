using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLLessonXStudentMapper
        {
                BOLessonXStudent MapModelToBO(
                        int id,
                        ApiLessonXStudentRequestModel model);

                ApiLessonXStudentResponseModel MapBOToModel(
                        BOLessonXStudent boLessonXStudent);

                List<ApiLessonXStudentResponseModel> MapBOToModel(
                        List<BOLessonXStudent> items);
        }
}

/*<Codenesium>
    <Hash>afb1802d5b7d5f9f3f0edba11daa1d2b</Hash>
</Codenesium>*/