using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITestAllFieldTypeService
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
    <Hash>ac580fa2f39b39d73a2a9410064e1881</Hash>
</Codenesium>*/