using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface ILessonService
        {
                Task<CreateResponse<ApiLessonResponseModel>> Create(
                        ApiLessonRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiLessonRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonResponseModel> Get(int id);

                Task<List<ApiLessonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>72e2b0d8a2ba79cab769bfa7132c9b5d</Hash>
</Codenesium>*/