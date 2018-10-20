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

		Task<List<ApiEventTeacherResponseModel>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillResponseModel>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f15df23706303faa02db87e3aea85358</Hash>
</Codenesium>*/