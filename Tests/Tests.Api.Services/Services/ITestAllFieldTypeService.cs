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

		Task<List<ApiTestAllFieldTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>0671bb4dbaebd53cde95074d487fc9f9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/