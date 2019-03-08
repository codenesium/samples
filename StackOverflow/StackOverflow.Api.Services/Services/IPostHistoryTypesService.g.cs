using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryTypesService
	{
		Task<CreateResponse<ApiPostHistoryTypesServerResponseModel>> Create(
			ApiPostHistoryTypesServerRequestModel model);

		Task<UpdateResponse<ApiPostHistoryTypesServerResponseModel>> Update(int id,
		                                                                     ApiPostHistoryTypesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryTypesServerResponseModel> Get(int id);

		Task<List<ApiPostHistoryTypesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostHistoryServerResponseModel>> PostHistoryByPostHistoryTypeId(int postHistoryTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>999f9646fc899b58fa7bb762665c70f5</Hash>
</Codenesium>*/