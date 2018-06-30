using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IDeploymentProcessService
        {
                Task<CreateResponse<ApiDeploymentProcessResponseModel>> Create(
                        ApiDeploymentProcessRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiDeploymentProcessRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiDeploymentProcessResponseModel> Get(string id);

                Task<List<ApiDeploymentProcessResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>cc7f32159762c2bf685bb1020088650d</Hash>
</Codenesium>*/