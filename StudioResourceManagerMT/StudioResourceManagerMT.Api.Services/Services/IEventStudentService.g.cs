using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventStudentService
	{
		Task<CreateResponse<ApiEventStudentServerResponseModel>> Create(
			ApiEventStudentServerRequestModel model);

		Task<UpdateResponse<ApiEventStudentServerResponseModel>> Update(int id,
		                                                                 ApiEventStudentServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStudentServerResponseModel> Get(int id);

		Task<List<ApiEventStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>a5fda2d63dec0e2c7b856b1fe8eac5d6</Hash>
</Codenesium>*/