using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public interface IErrorLogService
	{
		Task<CreateResponse<ApiErrorLogResponseModel>> Create(
			ApiErrorLogRequestModel model);

		Task<ActionResponse> Update(int errorLogID,
		                            ApiErrorLogRequestModel model);

		Task<ActionResponse> Delete(int errorLogID);

		Task<ApiErrorLogResponseModel> Get(int errorLogID);

		Task<List<ApiErrorLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a8d8dfa9cbbbf9ce7845b4e244f66024</Hash>
</Codenesium>*/