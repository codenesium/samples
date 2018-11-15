using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventService
	{
		Task<CreateResponse<ApiEventServerResponseModel>> Create(
			ApiEventServerRequestModel model);

		Task<UpdateResponse<ApiEventServerResponseModel>> Update(int id,
		                                                          ApiEventServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventServerResponseModel> Get(int id);

		Task<List<ApiEventServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> ByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a6a126fd6a4553f1a9688435dadc7341</Hash>
</Codenesium>*/