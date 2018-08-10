using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ISchemaVersionsService
	{
		Task<CreateResponse<ApiSchemaVersionsResponseModel>> Create(
			ApiSchemaVersionsRequestModel model);

		Task<UpdateResponse<ApiSchemaVersionsResponseModel>> Update(int id,
		                                                             ApiSchemaVersionsRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSchemaVersionsResponseModel> Get(int id);

		Task<List<ApiSchemaVersionsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>44d829bccd484d147649b1ed98ca94db</Hash>
</Codenesium>*/