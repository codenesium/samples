using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherTeacherSkillService
	{
		Task<CreateResponse<ApiTeacherTeacherSkillResponseModel>> Create(
			ApiTeacherTeacherSkillRequestModel model);

		Task<UpdateResponse<ApiTeacherTeacherSkillResponseModel>> Update(int id,
		                                                                  ApiTeacherTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherTeacherSkillResponseModel> Get(int id);

		Task<List<ApiTeacherTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8d92e995d4373683f55cba7488cf32a1</Hash>
</Codenesium>*/