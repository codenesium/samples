using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IStudioService
        {
                Task<CreateResponse<ApiStudioResponseModel>> Create(
                        ApiStudioRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiStudioRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiStudioResponseModel> Get(int id);

                Task<List<ApiStudioResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiAdminResponseModel>> Admins(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiFamilyResponseModel>> Families(int id, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLessonResponseModel>> Lessons(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiLessonStatusResponseModel>> LessonStatus(int id, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSpaceResponseModel>> Spaces(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSpaceFeatureResponseModel>> SpaceFeatures(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiStudentResponseModel>> Students(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiTeacherResponseModel>> Teachers(int studioId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiTeacherSkillResponseModel>> TeacherSkills(int studioId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>16a71ff67a50880ad0246031efe428f3</Hash>
</Codenesium>*/