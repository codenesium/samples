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

		Task<UpdateResponse<ApiEventStudentResponseModel>> Update(int eventId,
		                                                           ApiEventStudentRequestModel model);

		Task<ActionResponse> Delete(int eventId);

		Task<ApiEventStudentResponseModel> Get(int eventId);

		Task<List<ApiEventStudentResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>423d9042c2875409388ccdd4686ab483</Hash>
</Codenesium>*/