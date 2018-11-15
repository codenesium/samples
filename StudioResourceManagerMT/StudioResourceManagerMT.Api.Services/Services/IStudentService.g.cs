using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
	}
}

/*<Codenesium>
    <Hash>6545324ef73eaa9685c9b42d7c591dbe</Hash>
</Codenesium>*/