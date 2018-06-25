using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface ITenantVariableService
        {
                Task<CreateResponse<ApiTenantVariableResponseModel>> Create(
                        ApiTenantVariableRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiTenantVariableRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTenantVariableResponseModel> Get(string id);

                Task<List<ApiTenantVariableResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTenantVariableResponseModel> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

                Task<List<ApiTenantVariableResponseModel>> ByTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>37a683ece8283455ac52d6ddd946e536</Hash>
</Codenesium>*/