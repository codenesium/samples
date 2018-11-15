using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITestAllFieldTypeService
	{
		Task<CreateResponse<ApiTestAllFieldTypeServerResponseModel>> Create(
			ApiTestAllFieldTypeServerRequestModel model);

		Task<UpdateResponse<ApiTestAllFieldTypeServerResponseModel>> Update(int id,
		                                                                     ApiTestAllFieldTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTestAllFieldTypeServerResponseModel> Get(int id);

		Task<List<ApiTestAllFieldTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ea81046484c86e69228b55142bc53103</Hash>
</Codenesium>*/