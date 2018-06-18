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

                Task<List<ApiArtifactResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiArtifactResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>fe410a790ccca786eab65a74877c0699</Hash>
</Codenesium>*/