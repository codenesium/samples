using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface ITestAllFieldTypeService
	{
		Task<CreateResponse<ApiTestAllFieldTypeResponseModel>> Create(
			ApiTestAllFieldTypeRequestModel model);

		Task<UpdateResponse<ApiTestAllFieldTypeResponseModel>> Update(int id,
		                                                               ApiTestAllFieldTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTestAllFieldTypeResponseModel> Get(int id);

		Task<List<ApiTestAllFieldTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>749ae1df243316bcb02c0a2165d7b1a1</Hash>
</Codenesium>*/