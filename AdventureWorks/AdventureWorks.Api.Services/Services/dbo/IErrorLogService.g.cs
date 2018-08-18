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
    <Hash>380eb06b640cb6e1f84817d4d2e776cc</Hash>
</Codenesium>*/