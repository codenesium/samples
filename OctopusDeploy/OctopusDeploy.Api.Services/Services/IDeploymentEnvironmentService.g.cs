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

                Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiDeploymentEnvironmentResponseModel> GetName(string name);
                Task<List<ApiDeploymentEnvironmentResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>af4209cab1c74ffdc0c15da8f225b87c</Hash>
</Codenesium>*/