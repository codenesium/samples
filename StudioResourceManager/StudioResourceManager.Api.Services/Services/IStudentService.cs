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

		Task<List<ApiStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiStudentServerResponseModel>> ByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStudentServerResponseModel>> EventStudentsByStudentId(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>904f097972c1325a0fa2b8ed7dc7107d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/