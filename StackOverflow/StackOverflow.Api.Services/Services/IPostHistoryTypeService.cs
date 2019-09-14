using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryTypeService
	{
		Task<CreateResponse<ApiPostHistoryTypeServerResponseModel>> Create(
			ApiPostHistoryTypeServerRequestModel model);

		Task<UpdateResponse<ApiPostHistoryTypeServerResponseModel>> Update(int id,
		                                                                    ApiPostHistoryTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryTypeServerResponseModel> Get(int id);

		Task<List<ApiPostHistoryTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoriesByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8195dcc010cfb9f25e383ceab3bc25bd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/