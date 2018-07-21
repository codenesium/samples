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

                Task<UpdateResponse<ApiTenantVariableResponseModel>> Update(string id,
                                                                             ApiTenantVariableRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTenantVariableResponseModel> Get(string id);

                Task<List<ApiTenantVariableResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTenantVariableResponseModel> ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(string tenantId, string ownerId, string environmentId, string variableTemplateId);

                Task<List<ApiTenantVariableResponseModel>> ByTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>b841853e06e1103aec27d20e78163db1</Hash>
</Codenesium>*/