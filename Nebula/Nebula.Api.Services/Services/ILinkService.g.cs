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
    <Hash>f5acf15042b0c7efb5ef145cd16c81fb</Hash>
</Codenesium>*/