using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>e152569da56787ff1389c5c433041db5</Hash>
</Codenesium>*/