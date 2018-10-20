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

		Task<List<ApiRateResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillsByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>df1a0f68c3abdbb4b84f7c83ea246918</Hash>
</Codenesium>*/