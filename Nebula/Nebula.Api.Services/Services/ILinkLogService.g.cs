using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkLogService
	{
		Task<CreateResponse<ApiLinkLogServerResponseModel>> Create(
			ApiLinkLogServerRequestModel model);

		Task<UpdateResponse<ApiLinkLogServerResponseModel>> Update(int id,
		                                                            ApiLinkLogServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkLogServerResponseModel> Get(int id);

		Task<List<ApiLinkLogServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>247229ebfcb33e0dda8e45b8616407e2</Hash>
</Codenesium>*/