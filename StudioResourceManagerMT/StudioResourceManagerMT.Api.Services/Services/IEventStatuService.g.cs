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

		Task<List<ApiEventStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> EventsByEventStatusId(int eventStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>19517fb7ced8d890013281f50e3b5d38</Hash>
</Codenesium>*/