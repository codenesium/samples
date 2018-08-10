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
    <Hash>20c9685524850717124f188872c674fb</Hash>
</Codenesium>*/