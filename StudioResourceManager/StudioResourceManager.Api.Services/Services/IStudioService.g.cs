using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IStudioService
	{
		Task<CreateResponse<ApiStudioServerResponseModel>> Create(
			ApiStudioServerRequestModel model);

		Task<UpdateResponse<ApiStudioServerResponseModel>> Update(int id,
		                                                           ApiStudioServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiStudioServerResponseModel> Get(int id);

		Task<List<ApiStudioServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>1ec2244ef34fae386838f18a981443e7</Hash>
</Codenesium>*/