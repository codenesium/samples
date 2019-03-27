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

		Task<UpdateResponse<ApiEventStudentServerResponseModel>> Update(int eventId,
		                                                                 ApiEventStudentServerRequestModel model);

		Task<ActionResponse> Delete(int eventId);

		Task<ApiEventStudentServerResponseModel> Get(int eventId);

		Task<List<ApiEventStudentServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>c531b37cc29fa482966ed5053ee14714</Hash>
</Codenesium>*/