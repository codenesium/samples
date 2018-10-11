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

		Task<UpdateResponse<ApiTeacherTeacherSkillResponseModel>> Update(int teacherId,
		                                                                  ApiTeacherTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int teacherId);

		Task<ApiTeacherTeacherSkillResponseModel> Get(int teacherId);

		Task<List<ApiTeacherTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b26971e2365d61a7b73a045ec89bdfc9</Hash>
</Codenesium>*/