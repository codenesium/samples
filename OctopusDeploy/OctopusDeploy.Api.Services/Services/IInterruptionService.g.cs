using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IInterruptionService
        {
                Task<CreateResponse<ApiInterruptionResponseModel>> Create(
                        ApiInterruptionRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiInterruptionRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiInterruptionResponseModel> Get(string id);

                Task<List<ApiInterruptionResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiInterruptionResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>7229b5d51991a9fb23af435f691559a0</Hash>
</Codenesium>*/