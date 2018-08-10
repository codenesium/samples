using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkService
	{
		Task<CreateResponse<ApiLinkResponseModel>> Create(
			ApiLinkRequestModel model);

		Task<UpdateResponse<ApiLinkResponseModel>> Update(int id,
		                                                   ApiLinkRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkResponseModel> Get(int id);

		Task<List<ApiLinkResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiLinkLogResponseModel>> LinkLogs(int linkId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3d9a05a6a58ac08ded761da0278fbc5a</Hash>
</Codenesium>*/