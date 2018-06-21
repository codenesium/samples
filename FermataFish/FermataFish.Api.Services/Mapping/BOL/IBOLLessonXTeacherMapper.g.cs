using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLLessonXTeacherMapper
        {
                BOLessonXTeacher MapModelToBO(
                        int id,
                        ApiLessonXTeacherRequestModel model);

                ApiLessonXTeacherResponseModel MapBOToModel(
                        BOLessonXTeacher boLessonXTeacher);

                List<ApiLessonXTeacherResponseModel> MapBOToModel(
                        List<BOLessonXTeacher> items);
        }
}

/*<Codenesium>
    <Hash>4b9aa653977fb60b9a231cf9b76e2a72</Hash>
</Codenesium>*/