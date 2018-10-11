using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISchemaBPersonService
	{
		Task<CreateResponse<ApiSchemaBPersonResponseModel>> Create(
			ApiSchemaBPersonRequestModel model);

		Task<UpdateResponse<ApiSchemaBPersonResponseModel>> Update(int id,
		                                                            ApiSchemaBPersonRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaBPersonResponseModel> Get(int id);

		Task<List<ApiSchemaBPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ece2ec712c63f1b173efa3cfe2a8e59a</Hash>
</Codenesium>*/