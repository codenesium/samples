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

		Task<List<ApiTestAllFieldTypesNullableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>98095720032a82754d2c9e4f11f13c9f</Hash>
</Codenesium>*/