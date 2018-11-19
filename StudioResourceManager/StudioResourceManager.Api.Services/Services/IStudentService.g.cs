using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IStudentService
	{
		Task<CreateResponse<ApiStudentServerResponseModel>> Create(
			ApiStudentServerRequestModel model);

		Task<UpdateResponse<ApiStudentServerResponseModel>> Update(int id,
		                                                            ApiStudentServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentServerResponseModel> Get(int id);

		Task<List<ApiStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> ByEventId(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6ad63378682da147ea475c0e6ab5b909</Hash>
</Codenesium>*/