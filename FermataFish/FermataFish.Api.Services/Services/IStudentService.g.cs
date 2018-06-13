using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IStudentService
        {
                Task<CreateResponse<ApiStudentResponseModel>> Create(
                        ApiStudentRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiStudentRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiStudentResponseModel> Get(int id);

                Task<List<ApiStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiLessonXStudentResponseModel>> LessonXStudents(int studentId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLessonXTeacherResponseModel>> LessonXTeachers(int studentId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int studentId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>afb754c4b2bde0209a286281524aeabc</Hash>
</Codenesium>*/