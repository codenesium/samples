using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IMessengerService
	{
		Task<CreateResponse<ApiMessengerResponseModel>> Create(
			ApiMessengerRequestModel model);

		Task<UpdateResponse<ApiMessengerResponseModel>> Update(int id,
		                                                        ApiMessengerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMessengerResponseModel> Get(int id);

		Task<List<ApiMessengerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> ByMessageId(int? messageId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> ByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>67ac99970079f9504db33dd1f9ac45d7</Hash>
</Codenesium>*/