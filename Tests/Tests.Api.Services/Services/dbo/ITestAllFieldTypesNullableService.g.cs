using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface ITestAllFieldTypesNullableService
	{
		Task<CreateResponse<ApiTestAllFieldTypesNullableResponseModel>> Create(
			ApiTestAllFieldTypesNullableRequestModel model);

		Task<UpdateResponse<ApiTestAllFieldTypesNullableResponseModel>> Update(int id,
		                                                                        ApiTestAllFieldTypesNullableRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTestAllFieldTypesNullableResponseModel> Get(int id);

		Task<List<ApiTestAllFieldTypesNullableResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>41553aeece3387e2701f1078ac3844f6</Hash>
</Codenesium>*/