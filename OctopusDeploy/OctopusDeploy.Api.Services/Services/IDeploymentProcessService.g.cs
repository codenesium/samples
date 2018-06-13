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

                Task<List<ApiDeploymentProcessResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>baaa990140e1ec796588cdae0df9cdab</Hash>
</Codenesium>*/