using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IArtifactService
        {
                Task<CreateResponse<ApiArtifactResponseModel>> Create(
                        ApiArtifactRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiArtifactRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiArtifactResponseModel> Get(string id);

                Task<List<ApiArtifactResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiArtifactResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>dcac331b73c98986ffd6a9a61e9d8985</Hash>
</Codenesium>*/