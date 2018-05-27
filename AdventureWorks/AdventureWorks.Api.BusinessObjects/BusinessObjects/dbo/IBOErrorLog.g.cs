using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOErrorLog
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
    <Hash>b1754951652c41eec3387b13e104c4b1</Hash>
</Codenesium>*/