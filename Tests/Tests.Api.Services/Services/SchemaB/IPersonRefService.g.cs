using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IPersonRefService
	{
		Task<CreateResponse<ApiPersonRefServerResponseModel>> Create(
			ApiPersonRefServerRequestModel model);

		Task<UpdateResponse<ApiPersonRefServerResponseModel>> Update(int id,
		                                                              ApiPersonRefServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPersonRefServerResponseModel> Get(int id);

		Task<List<ApiPersonRefServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>65608fa08618fcf9a2f7f03ddc6c074c</Hash>
</Codenesium>*/