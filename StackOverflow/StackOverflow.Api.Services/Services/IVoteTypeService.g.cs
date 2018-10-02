using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IVoteTypeService
	{
		Task<CreateResponse<ApiVoteTypeResponseModel>> Create(
			ApiVoteTypeRequestModel model);

		Task<UpdateResponse<ApiVoteTypeResponseModel>> Update(int id,
		                                                       ApiVoteTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVoteTypeResponseModel> Get(int id);

		Task<List<ApiVoteTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>63cd250e26bb70a5a4f99ac144aa0f6a</Hash>
</Codenesium>*/