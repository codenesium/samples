using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagsService
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
    <Hash>a7d0eb1d4fca55714931b11389c62fe2</Hash>
</Codenesium>*/