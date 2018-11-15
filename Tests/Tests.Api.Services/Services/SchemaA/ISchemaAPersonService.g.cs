using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISchemaAPersonService
	{
		Task<CreateResponse<ApiSchemaAPersonServerResponseModel>> Create(
			ApiSchemaAPersonServerRequestModel model);

		Task<UpdateResponse<ApiSchemaAPersonServerResponseModel>> Update(int id,
		                                                                  ApiSchemaAPersonServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaAPersonServerResponseModel> Get(int id);

		Task<List<ApiSchemaAPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9441308a6d747752ec2ca918f97844c8</Hash>
</Codenesium>*/