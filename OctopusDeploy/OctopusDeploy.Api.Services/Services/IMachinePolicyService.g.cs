using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IMachinePolicyService
        {
                Task<CreateResponse<ApiMachinePolicyResponseModel>> Create(
                        ApiMachinePolicyRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiMachinePolicyRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiMachinePolicyResponseModel> Get(string id);

                Task<List<ApiMachinePolicyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiMachinePolicyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>113e252208d13937b1ffdc8233d6e224</Hash>
</Codenesium>*/