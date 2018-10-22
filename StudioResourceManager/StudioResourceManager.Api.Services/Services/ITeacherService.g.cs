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

		Task<List<ApiRateResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherResponseModel>> ByTeacherSkillId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>81a07e21760a13e303c7fddf3aa82628</Hash>
</Codenesium>*/