using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherService
	{
		Task<CreateResponse<ApiTeacherResponseModel>> Create(
			ApiTeacherRequestModel model);

		Task<UpdateResponse<ApiTeacherResponseModel>> Update(int id,
		                                                      ApiTeacherRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherResponseModel> Get(int id);

		Task<List<ApiTeacherResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherResponseModel>> EventTeachers(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> ByEventId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> ByTeacherSkillId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5deab884d8cc97e92b52b4cc5fb7d7b3</Hash>
</Codenesium>*/