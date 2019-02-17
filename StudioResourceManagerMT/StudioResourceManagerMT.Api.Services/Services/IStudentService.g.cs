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

		Task<List<ApiStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>31f873d31fabf6dbf3cb4c40f7612642</Hash>
</Codenesium>*/