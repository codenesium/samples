using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>317567f4fb8fe1f1f3033dfaa950f780</Hash>
</Codenesium>*/