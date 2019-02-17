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
	}
}

/*<Codenesium>
    <Hash>60dd22ac9980bdc20e6802bcd0ed4b53</Hash>
</Codenesium>*/