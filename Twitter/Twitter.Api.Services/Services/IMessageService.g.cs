using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial interface IMessageService
	{
		Task<CreateResponse<ApiMessageResponseModel>> Create(
			ApiMessageRequestModel model);

		Task<UpdateResponse<ApiMessageResponseModel>> Update(int messageId,
		                                                      ApiMessageRequestModel model);

		Task<ActionResponse> Delete(int messageId);

		Task<ApiMessageResponseModel> Get(int messageId);

		Task<List<ApiMessageResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessageResponseModel>> BySenderUserId(int? senderUserId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiMessengerResponseModel>> Messengers(int messageId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b908cf84bb6a5e6e1dd314bf6e999330</Hash>
</Codenesium>*/