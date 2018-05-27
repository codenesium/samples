using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOVersionInfo
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
    <Hash>174371a562015f1b087bfd9a8d80331e</Hash>
</Codenesium>*/