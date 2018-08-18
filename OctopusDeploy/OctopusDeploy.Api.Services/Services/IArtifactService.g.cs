using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IArtifactService
	{
		Task<CreateResponse<ApiArtifactResponseModel>> Create(
			ApiArtifactRequestModel model);

		Task<UpdateResponse<ApiArtifactResponseModel>> Update(string id,
		                                                       ApiArtifactRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiArtifactResponseModel> Get(string id);

		Task<List<ApiArtifactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiArtifactResponseModel>> ByTenantId(string tenantId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>fc9cce2baf8237c00baea1f2b8f6080c</Hash>
</Codenesium>*/