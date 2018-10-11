using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IStudentService
	{
		Task<CreateResponse<ApiStudentResponseModel>> Create(
			ApiStudentRequestModel model);

		Task<UpdateResponse<ApiStudentResponseModel>> Update(int id,
		                                                      ApiStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudentResponseModel> Get(int id);

		Task<List<ApiStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventStudentResponseModel>> EventStudents(int studentId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiStudentResponseModel>> ByEventId(int studentId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7617a7382f8fabd0a40953d8d9ed2560</Hash>
</Codenesium>*/