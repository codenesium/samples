using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface ILinkLogService
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
    <Hash>bd2bd770e403f57a7f52559b5cd52b8b</Hash>
</Codenesium>*/