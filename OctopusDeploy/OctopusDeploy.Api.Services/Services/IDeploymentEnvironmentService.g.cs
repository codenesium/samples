using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiDeploymentEnvironmentResponseModel> GetName(string name);
                Task<List<ApiDeploymentEnvironmentResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>05a0640a9888a9a401739584e105dcaf</Hash>
</Codenesium>*/