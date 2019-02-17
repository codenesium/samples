using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ITeacherService
	{
		Task<CreateResponse<ApiTeacherServerResponseModel>> Create(
			ApiTeacherServerRequestModel model);

		Task<UpdateResponse<ApiTeacherServerResponseModel>> Update(int id,
		                                                            ApiTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherServerResponseModel> Get(int id);

		Task<List<ApiTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTeacherServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>24cf13a7fb23b890186e926361a4be7e</Hash>
</Codenesium>*/