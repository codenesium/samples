using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IVersionInfoService
	{
		Task<CreateResponse<ApiVersionInfoServerResponseModel>> Create(
			ApiVersionInfoServerRequestModel model);

		Task<UpdateResponse<ApiVersionInfoServerResponseModel>> Update(long version,
		                                                                ApiVersionInfoServerRequestModel model);

		Task<ActionResponse> Delete(long version);

		Task<ApiVersionInfoServerResponseModel> Get(long version);

		Task<List<ApiVersionInfoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6967d1728a6eaa194e2f3db1fbf57100</Hash>
</Codenesium>*/