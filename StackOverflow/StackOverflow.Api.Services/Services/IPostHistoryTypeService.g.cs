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
	}
}

/*<Codenesium>
    <Hash>afe1ed4c46c13ae1985ea7ced32fac17</Hash>
</Codenesium>*/