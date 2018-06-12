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

                Task<List<ApiTenantVariableResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiTenantVariableResponseModel> GetTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);
                Task<List<ApiTenantVariableResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>f0aa483ec52854dbccd60332c54945ef</Hash>
</Codenesium>*/