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

		Task<List<ApiMessengerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiMessengerServerResponseModel>> ByMessageId(int? messageId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> ByToUserId(int toUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> ByUserId(int? userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f73359f76f14b8e1acabd0e93af90794</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/