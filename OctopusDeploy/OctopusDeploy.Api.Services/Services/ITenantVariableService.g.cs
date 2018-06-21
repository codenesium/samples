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

                Task<ApiTenantVariableResponseModel> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

                Task<List<ApiTenantVariableResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>32f369572e9eb902287ccc92f2411db1</Hash>
</Codenesium>*/