using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IChannelService
	{
		Task<CreateResponse<ApiChannelResponseModel>> Create(
			ApiChannelRequestModel model);

		Task<UpdateResponse<ApiChannelResponseModel>> Update(string id,
		                                                      ApiChannelRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiChannelResponseModel> Get(string id);

		Task<List<ApiChannelResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiChannelResponseModel> ByNameProjectId(string name, string projectId);

		Task<List<ApiChannelResponseModel>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiChannelResponseModel>> ByProjectId(string projectId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e03750bcde778363831e32652043eb37</Hash>
</Codenesium>*/