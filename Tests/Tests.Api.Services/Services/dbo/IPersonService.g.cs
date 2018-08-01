using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IPersonService
	{
		Task<CreateResponse<ApiPersonResponseModel>> Create(
			ApiPersonRequestModel model);

		Task<UpdateResponse<ApiPersonResponseModel>> Update(int personId,
		                                                     ApiPersonRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiPersonResponseModel> Get(int personId);

		Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>cdc9b0cf5d3ab4a233c4ddb933041e65</Hash>
</Codenesium>*/