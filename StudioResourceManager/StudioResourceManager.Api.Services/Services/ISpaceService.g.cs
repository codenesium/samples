using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ISpaceService
	{
		Task<CreateResponse<ApiSpaceServerResponseModel>> Create(
			ApiSpaceServerRequestModel model);

		Task<UpdateResponse<ApiSpaceServerResponseModel>> Update(int id,
		                                                          ApiSpaceServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpaceServerResponseModel> Get(int id);

		Task<List<ApiSpaceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6dcd6e727dbbe74db86db838021737dc</Hash>
</Codenesium>*/