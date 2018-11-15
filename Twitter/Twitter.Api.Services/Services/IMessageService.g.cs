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

		Task<List<ApiMessageServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessageServerResponseModel>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerServerResponseModel>> MessengersByMessageId(int messageId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1dbb3d6179e171adc5572fe82de333e3</Hash>
</Codenesium>*/