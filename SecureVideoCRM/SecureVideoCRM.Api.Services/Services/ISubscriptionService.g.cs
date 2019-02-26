using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface ISubscriptionService
	{
		Task<CreateResponse<ApiSubscriptionServerResponseModel>> Create(
			ApiSubscriptionServerRequestModel model);

		Task<UpdateResponse<ApiSubscriptionServerResponseModel>> Update(int id,
		                                                                 ApiSubscriptionServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSubscriptionServerResponseModel> Get(int id);

		Task<List<ApiSubscriptionServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiUserServerResponseModel>> UsersBySubscriptionId(int subscriptionId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2022c74a59e7f88c9781cb1344ef2ae0</Hash>
</Codenesium>*/