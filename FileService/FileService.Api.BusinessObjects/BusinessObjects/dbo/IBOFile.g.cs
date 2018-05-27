using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOFile
	{
		Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiFileRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiFileResponseModel> Get(int id);

		Task<List<ApiFileResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>219b9d58e978e9eadfc67ba741520649</Hash>
</Codenesium>*/