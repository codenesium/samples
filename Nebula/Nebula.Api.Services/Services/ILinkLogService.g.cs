using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface ILinkLogService
	{
		Task<CreateResponse<ApiLinkLogResponseModel>> Create(
			ApiLinkLogRequestModel model);

		Task<UpdateResponse<ApiLinkLogResponseModel>> Update(int id,
		                                                      ApiLinkLogRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkLogResponseModel> Get(int id);

		Task<List<ApiLinkLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a219d417f423d4ad59a03548e3753829</Hash>
</Codenesium>*/