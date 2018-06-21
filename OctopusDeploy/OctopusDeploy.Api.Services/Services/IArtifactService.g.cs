using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiArtifactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiArtifactResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>42da63032badb5cb35c4845ca6122780</Hash>
</Codenesium>*/