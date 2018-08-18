using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
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

		Task<List<ApiRateResponseModel>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherXTeacherSkillResponseModel>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>601f8e940070249fa81ffa64312c2eb5</Hash>
</Codenesium>*/