using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IErrorLogService
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
    <Hash>99b9870927724dc4b5231ec8213dc1c2</Hash>
</Codenesium>*/