using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IEventStatuService
	{
		Task<CreateResponse<ApiEventStatuServerResponseModel>> Create(
			ApiEventStatuServerRequestModel model);

		Task<UpdateResponse<ApiEventStatuServerResponseModel>> Update(int id,
		                                                               ApiEventStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiEventStatuServerResponseModel> Get(int id);

		Task<List<ApiEventStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fb52d3b51e2e009aecb788ac711ae787</Hash>
</Codenesium>*/