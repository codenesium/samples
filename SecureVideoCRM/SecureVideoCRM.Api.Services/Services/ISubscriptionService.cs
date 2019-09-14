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
	}
}

/*<Codenesium>
    <Hash>7098c20c6fa684d04a08aa9866c1fa70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/