using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IErrorLogService
	{
		Task<CreateResponse<ApiErrorLogServerResponseModel>> Create(
			ApiErrorLogServerRequestModel model);

		Task<UpdateResponse<ApiErrorLogServerResponseModel>> Update(int errorLogID,
		                                                             ApiErrorLogServerRequestModel model);

		Task<ActionResponse> Delete(int errorLogID);

		Task<ApiErrorLogServerResponseModel> Get(int errorLogID);

		Task<List<ApiErrorLogServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5534019d244c28c5765549a55ed88676</Hash>
</Codenesium>*/