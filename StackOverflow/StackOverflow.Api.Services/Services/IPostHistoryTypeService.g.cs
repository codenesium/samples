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

		Task<List<ApiPostHistoryTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d8c1ef53f64147aa2671c07045f32bdf</Hash>
</Codenesium>*/