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

		Task<List<ApiEventServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>76604c3cc9b72f8ac97988468f58a71b</Hash>
</Codenesium>*/