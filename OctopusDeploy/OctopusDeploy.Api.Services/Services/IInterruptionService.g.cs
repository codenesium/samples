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

                Task<List<ApiInterruptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiInterruptionResponseModel>> GetTenantId(string tenantId);
        }
}

/*<Codenesium>
    <Hash>c60bc4894697c72ce4b12afe0f0b9b71</Hash>
</Codenesium>*/