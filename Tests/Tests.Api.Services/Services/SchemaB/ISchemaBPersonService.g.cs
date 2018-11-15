using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISchemaBPersonService
	{
		Task<CreateResponse<ApiSchemaBPersonServerResponseModel>> Create(
			ApiSchemaBPersonServerRequestModel model);

		Task<UpdateResponse<ApiSchemaBPersonServerResponseModel>> Update(int id,
		                                                                  ApiSchemaBPersonServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaBPersonServerResponseModel> Get(int id);

		Task<List<ApiSchemaBPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>baf7c19c114a7c39db0e14cb77a68ef6</Hash>
</Codenesium>*/