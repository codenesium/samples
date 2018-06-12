using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiDeploymentProcessResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f95fc5e7e9eea7d2a700c96901a6095b</Hash>
</Codenesium>*/