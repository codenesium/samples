using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOLinkLog
	{
		Task<CreateResponse<ApiLinkLogResponseModel>> Create(
			ApiLinkLogRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiLinkLogRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkLogResponseModel> Get(int id);

		Task<List<ApiLinkLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e3f6477d2f9a7453d8ea16fd27061e7b</Hash>
</Codenesium>*/