using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IMessengerService
	{
		Task<CreateResponse<ApiMessengerServerResponseModel>> Create(
			ApiMessengerServerRequestModel model);

		Task<UpdateResponse<ApiMessengerServerResponseModel>> Update(int id,
		                                                              ApiMessengerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiMessengerServerResponseModel> Get(int id);

		Task<List<ApiMessengerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> ByMessageId(int? messageId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> ByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cb461278129c56267d14cc0dfe1ab9f2</Hash>
</Codenesium>*/