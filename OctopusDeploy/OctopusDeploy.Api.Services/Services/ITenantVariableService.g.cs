using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<ApiTenantVariableResponseModel> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);
                Task<List<ApiTenantVariableResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>2bb2a7bd074dc34e8f81016364ad4219</Hash>
</Codenesium>*/