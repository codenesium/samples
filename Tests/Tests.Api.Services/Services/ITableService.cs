using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITableService
	{
		Task<CreateResponse<ApiTableServerResponseModel>> Create(
			ApiTableServerRequestModel model);

		Task<UpdateResponse<ApiTableServerResponseModel>> Update(int id,
		                                                          ApiTableServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTableServerResponseModel> Get(int id);

		Task<List<ApiTableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>21e875daf3f5c4fad838bfd89cdbe434</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/