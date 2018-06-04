using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
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
    <Hash>3f7026d011d7f19cdc5cb9f86d9e7fb3</Hash>
</Codenesium>*/