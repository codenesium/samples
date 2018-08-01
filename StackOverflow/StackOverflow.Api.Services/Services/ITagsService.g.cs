using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface ITagsService
	{
		Task<CreateResponse<ApiTagsResponseModel>> Create(
			ApiTagsRequestModel model);

		Task<UpdateResponse<ApiTagsResponseModel>> Update(int id,
		                                                   ApiTagsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagsResponseModel> Get(int id);

		Task<List<ApiTagsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>84a96acabd0b663689c59047987ecf51</Hash>
</Codenesium>*/