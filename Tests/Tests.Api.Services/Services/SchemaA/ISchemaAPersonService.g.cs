using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISchemaAPersonService
	{
		Task<CreateResponse<ApiSchemaAPersonResponseModel>> Create(
			ApiSchemaAPersonRequestModel model);

		Task<UpdateResponse<ApiSchemaAPersonResponseModel>> Update(int id,
		                                                            ApiSchemaAPersonRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaAPersonResponseModel> Get(int id);

		Task<List<ApiSchemaAPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>87dd65570cbe2412df2641acdd6f04a9</Hash>
</Codenesium>*/