using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiInterruptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiInterruptionResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>f4949441c9d6393d86d4b2030c4af2ba</Hash>
</Codenesium>*/