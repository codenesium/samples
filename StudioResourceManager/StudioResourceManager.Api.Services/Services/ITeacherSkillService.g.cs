using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherSkillService
	{
		Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
			ApiTeacherSkillRequestModel model);

		Task<UpdateResponse<ApiTeacherSkillResponseModel>> Update(int id,
		                                                           ApiTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherSkillResponseModel> Get(int id);

		Task<List<ApiTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateResponseModel>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherSkillResponseModel>> ByTeacherId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2561d0825d33da9d133a55a6943a17a9</Hash>
</Codenesium>*/