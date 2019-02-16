using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITestAllFieldTypesNullableService
	{
		Task<CreateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Create(
			ApiTestAllFieldTypesNullableServerRequestModel model);

		Task<UpdateResponse<ApiTestAllFieldTypesNullableServerResponseModel>> Update(int id,
		                                                                              ApiTestAllFieldTypesNullableServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTestAllFieldTypesNullableServerResponseModel> Get(int id);

		Task<List<ApiTestAllFieldTypesNullableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>d09c8da64ef8139433ba5c8f37f17097</Hash>
</Codenesium>*/