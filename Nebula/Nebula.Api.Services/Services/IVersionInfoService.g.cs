using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
	public interface IVersionInfoService
	{
		Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model);

		Task<ActionResponse> Update(long version,
		                            ApiVersionInfoRequestModel model);

		Task<ActionResponse> Delete(long version);

		Task<ApiVersionInfoResponseModel> Get(long version);

		Task<List<ApiVersionInfoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ApiVersionInfoResponseModel> GetVersion(long version);
	}
}

/*<Codenesium>
    <Hash>6abeb8e47ec8faf0555d17ca2fdc544b</Hash>
</Codenesium>*/