using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryTypeService
	{
		Task<CreateResponse<ApiPostHistoryTypeResponseModel>> Create(
			ApiPostHistoryTypeRequestModel model);

		Task<UpdateResponse<ApiPostHistoryTypeResponseModel>> Update(int id,
		                                                              ApiPostHistoryTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryTypeResponseModel> Get(int id);

		Task<List<ApiPostHistoryTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>08d7841569f41c5dd35a1fc904db8e09</Hash>
</Codenesium>*/