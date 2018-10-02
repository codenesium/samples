using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventStudentService
	{
		Task<CreateResponse<ApiEventStudentResponseModel>> Create(
			ApiEventStudentRequestModel model);

		Task<UpdateResponse<ApiEventStudentResponseModel>> Update(int id,
		                                                           ApiEventStudentRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStudentResponseModel> Get(int id);

		Task<List<ApiEventStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a20bbf439edbbbf56e42ca2724599d19</Hash>
</Codenesium>*/