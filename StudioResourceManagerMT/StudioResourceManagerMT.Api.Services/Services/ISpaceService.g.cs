using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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

		Task<List<ApiSpaceSpaceFeatureServerResponseModel>> SpaceSpaceFeaturesBySpaceId(int spaceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>24bd02fbdf2fcd76a24a56eacab11ece</Hash>
</Codenesium>*/