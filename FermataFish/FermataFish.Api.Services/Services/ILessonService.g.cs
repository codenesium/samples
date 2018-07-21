using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public interface ILessonService
        {
                Task<CreateResponse<ApiLessonResponseModel>> Create(
                        ApiLessonRequestModel model);

                Task<UpdateResponse<ApiLessonResponseModel>> Update(int id,
                                                                     ApiLessonRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiLessonResponseModel> Get(int id);

                Task<List<ApiLessonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ae888a8f6f80b9204a6a00a0f8233036</Hash>
</Codenesium>*/