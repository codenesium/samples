using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBadgeService
	{
		Task<CreateResponse<ApiBadgeResponseModel>> Create(
			ApiBadgeRequestModel model);

		Task<UpdateResponse<ApiBadgeResponseModel>> Update(int id,
		                                                    ApiBadgeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBadgeResponseModel> Get(int id);

		Task<List<ApiBadgeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>90b2823e3fa0af6e60f46e88e5e98d9d</Hash>
</Codenesium>*/