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

                Task<ApiDeploymentEnvironmentResponseModel> GetName(string name);

                Task<List<ApiDeploymentEnvironmentResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>bc569c1537a8c89f3b3978f6632340a4</Hash>
</Codenesium>*/