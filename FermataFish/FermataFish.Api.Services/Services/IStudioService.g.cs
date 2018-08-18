using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface IStudioService
	{
		Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model);

		Task<UpdateResponse<ApiStudioResponseModel>> Update(int id,
		                                                     ApiStudioRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioResponseModel> Get(int id);

		Task<List<ApiStudioResponseModel>> All(int limit = int.MaxValue, int offset = 0);

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
    <Hash>a7042d88bbea649fdcb6c9b956d1435f</Hash>
</Codenesium>*/