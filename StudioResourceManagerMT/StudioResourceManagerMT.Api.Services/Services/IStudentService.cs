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

		Task<List<ApiEventStudentServerResponseModel>> EventStudentsByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>aa4df2e0382de3dbcfc2f8736bf26d27</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/