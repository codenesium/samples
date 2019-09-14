using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherTeacherSkillService
	{
		Task<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>> Create(
			ApiTeacherTeacherSkillServerRequestModel model);

		Task<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>> Update(int id,
		                                                                        ApiTeacherTeacherSkillServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherTeacherSkillServerResponseModel> Get(int id);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d90da6b3ee6c5f2e99a7296871504c77</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/