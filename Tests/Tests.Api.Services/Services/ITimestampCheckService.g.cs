using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITimestampCheckService
	{
		Task<CreateResponse<ApiTimestampCheckServerResponseModel>> Create(
			ApiTimestampCheckServerRequestModel model);

		Task<UpdateResponse<ApiTimestampCheckServerResponseModel>> Update(int id,
		                                                                   ApiTimestampCheckServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTimestampCheckServerResponseModel> Get(int id);

		Task<List<ApiTimestampCheckServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d4c91198cebba66c20b26e45be12f4fc</Hash>
</Codenesium>*/