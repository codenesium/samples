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

                Task<UpdateResponse<ApiDeploymentEnvironmentResponseModel>> Update(string id,
                                                                                    ApiDeploymentEnvironmentRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDeploymentEnvironmentResponseModel> Get(string id);

                Task<List<ApiDeploymentEnvironmentResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiDeploymentEnvironmentResponseModel> ByName(string name);

                Task<List<ApiDeploymentEnvironmentResponseModel>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>8ae951fb6309b2ad8dc0770f68590fcb</Hash>
</Codenesium>*/