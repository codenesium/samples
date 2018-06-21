using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiMachinePolicyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiMachinePolicyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>cc9337d625cfabc21b9e201ce73802e8</Hash>
</Codenesium>*/