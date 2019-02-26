using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IUserService
	{
		Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model);

		Task<UpdateResponse<ApiUserServerResponseModel>> Update(int id,
		                                                         ApiUserServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiUserServerResponseModel> Get(int id);

		Task<List<ApiUserServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiUserServerResponseModel>> BySubscriptionId(int subscriptionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>956120f4b646d1b346564ebd5af95eda</Hash>
</Codenesium>*/