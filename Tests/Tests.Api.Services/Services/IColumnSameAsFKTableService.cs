using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IColumnSameAsFKTableService
	{
		Task<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>> Create(
			ApiColumnSameAsFKTableServerRequestModel model);

		Task<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>> Update(int id,
		                                                                        ApiColumnSameAsFKTableServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiColumnSameAsFKTableServerResponseModel> Get(int id);

		Task<List<ApiColumnSameAsFKTableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>a5cc3ee90cc2f25d092e035b066deb23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/