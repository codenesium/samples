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

		Task<List<ApiArtifactResponseModel>> ByTenantId(string tenantId);
	}
}

/*<Codenesium>
    <Hash>7e39f174069adba3ec89f07b83b0caec</Hash>
</Codenesium>*/