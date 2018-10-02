using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagService
	{
		Task<CreateResponse<ApiTagResponseModel>> Create(
			ApiTagRequestModel model);

		Task<UpdateResponse<ApiTagResponseModel>> Update(int id,
		                                                  ApiTagRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagResponseModel> Get(int id);

		Task<List<ApiTagResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c1c1a710f6ad3ee07d6b99386ceaf426</Hash>
</Codenesium>*/