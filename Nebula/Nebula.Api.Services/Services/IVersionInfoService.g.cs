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

		Task<List<ApiVersionInfoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>745e6b0064aa18c487d0a5c6b0c68183</Hash>
</Codenesium>*/