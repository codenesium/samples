using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IIncludedColumnTestService
	{
		Task<CreateResponse<ApiIncludedColumnTestResponseModel>> Create(
			ApiIncludedColumnTestRequestModel model);

		Task<UpdateResponse<ApiIncludedColumnTestResponseModel>> Update(int id,
		                                                                 ApiIncludedColumnTestRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiIncludedColumnTestResponseModel> Get(int id);

		Task<List<ApiIncludedColumnTestResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>24d7cca89778abc0efa7d17a61b89546</Hash>
</Codenesium>*/