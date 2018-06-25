using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IDeploymentEnvironmentService
        {
                Task<CreateResponse<ApiDeploymentEnvironmentResponseModel>> Create(
                        ApiDeploymentEnvironmentRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiDeploymentEnvironmentRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDeploymentEnvironmentResponseModel> Get(string id);

                Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiDeploymentEnvironmentResponseModel> ByName(string name);

                Task<List<ApiDeploymentEnvironmentResponseModel>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>48ad3f4fc3c1f0fe8a7118c17b45d8ec</Hash>
</Codenesium>*/