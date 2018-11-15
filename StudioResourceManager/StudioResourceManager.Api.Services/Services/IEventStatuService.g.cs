using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IEventStatuService
	{
		Task<CreateResponse<ApiEventStatuServerResponseModel>> Create(
			ApiEventStatuServerRequestModel model);

		Task<UpdateResponse<ApiEventStatuServerResponseModel>> Update(int id,
		                                                               ApiEventStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStatuServerResponseModel> Get(int id);

		Task<List<ApiEventStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d5f0aa2f0153f9c0f254dcb17c6ac153</Hash>
</Codenesium>*/