using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISchemaBPersonService
	{
		Task<CreateResponse<ApiSchemaBPersonResponseModel>> Create(
			ApiSchemaBPersonRequestModel model);

		Task<UpdateResponse<ApiSchemaBPersonResponseModel>> Update(int id,
		                                                            ApiSchemaBPersonRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaBPersonResponseModel> Get(int id);

		Task<List<ApiSchemaBPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiPersonRefResponseModel>> PersonRefs(int personBId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>552f8d294b05a9509c23de911d8c23b9</Hash>
</Codenesium>*/