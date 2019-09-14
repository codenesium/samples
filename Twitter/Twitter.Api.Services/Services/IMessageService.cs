using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IMessageService
	{
		Task<CreateResponse<ApiMessageServerResponseModel>> Create(
			ApiMessageServerRequestModel model);

		Task<UpdateResponse<ApiMessageServerResponseModel>> Update(int messageId,
		                                                            ApiMessageServerRequestModel model);

		Task<ActionResponse> Delete(int messageId);

		Task<ApiMessageServerResponseModel> Get(int messageId);

		Task<List<ApiMessageServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiMessageServerResponseModel>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f7816984dce654b95c4921b005a71f80</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/