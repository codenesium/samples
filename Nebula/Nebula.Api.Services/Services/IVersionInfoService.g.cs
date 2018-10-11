using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IVersionInfoService
	{
		Task<CreateResponse<ApiVersionInfoResponseModel>> Create(
			ApiVersionInfoRequestModel model);

		Task<UpdateResponse<ApiVersionInfoResponseModel>> Update(long version,
		                                                          ApiVersionInfoRequestModel model);

		Task<ActionResponse> Delete(long version);

		Task<ApiVersionInfoResponseModel> Get(long version);

		Task<List<ApiVersionInfoResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bbe983cff62fcbd1177f13406f68cfef</Hash>
</Codenesium>*/