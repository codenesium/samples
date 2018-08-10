using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBadgesService
	{
		Task<CreateResponse<ApiBadgesResponseModel>> Create(
			ApiBadgesRequestModel model);

		Task<UpdateResponse<ApiBadgesResponseModel>> Update(int id,
		                                                     ApiBadgesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBadgesResponseModel> Get(int id);

		Task<List<ApiBadgesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dfa0aa781d4f831c5754a93d387ec851</Hash>
</Codenesium>*/