using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonService
	{
		Task<CreateResponse<ApiPersonServerResponseModel>> Create(
			ApiPersonServerRequestModel model);

		Task<UpdateResponse<ApiPersonServerResponseModel>> Update(int personId,
		                                                           ApiPersonServerRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiPersonServerResponseModel> Get(int personId);

		Task<List<ApiPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a7731710ce39fbc0d24b31942bc978be</Hash>
</Codenesium>*/