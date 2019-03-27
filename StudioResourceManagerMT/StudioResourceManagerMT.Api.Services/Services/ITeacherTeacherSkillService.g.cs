using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ITeacherTeacherSkillService
	{
		Task<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>> Create(
			ApiTeacherTeacherSkillServerRequestModel model);

		Task<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>> Update(int teacherId,
		                                                                        ApiTeacherTeacherSkillServerRequestModel model);

		Task<ActionResponse> Delete(int teacherId);

		Task<ApiTeacherTeacherSkillServerResponseModel> Get(int teacherId);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>f16c7a0da75fe06e64bad90c27e0e035</Hash>
</Codenesium>*/