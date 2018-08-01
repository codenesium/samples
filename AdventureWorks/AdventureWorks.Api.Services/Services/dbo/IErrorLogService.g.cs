using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IErrorLogService
	{
		Task<CreateResponse<ApiErrorLogResponseModel>> Create(
			ApiErrorLogRequestModel model);

		Task<UpdateResponse<ApiErrorLogResponseModel>> Update(int errorLogID,
		                                                       ApiErrorLogRequestModel model);

		Task<ActionResponse> Delete(int errorLogID);

		Task<ApiErrorLogResponseModel> Get(int errorLogID);

		Task<List<ApiErrorLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e95fd7947858d00e5a302ad6e49a989b</Hash>
</Codenesium>*/