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

		Task<List<ApiColumnSameAsFKTableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8d6f8af8deb1f55479f6558c58eb3925</Hash>
</Codenesium>*/