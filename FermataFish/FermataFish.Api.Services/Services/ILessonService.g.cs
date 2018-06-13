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

                Task<List<ApiLessonResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int lessonId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int lessonId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>069c3bf6a01ce60e8c2b020feb9bd488</Hash>
</Codenesium>*/