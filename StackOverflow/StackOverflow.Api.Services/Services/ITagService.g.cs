using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagService
	{
		Task<CreateResponse<ApiTagServerResponseModel>> Create(
			ApiTagServerRequestModel model);

		Task<UpdateResponse<ApiTagServerResponseModel>> Update(int id,
		                                                        ApiTagServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagServerResponseModel> Get(int id);

		Task<List<ApiTagServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4c0d66586737f3698d6f3315a5e4dd4a</Hash>
</Codenesium>*/