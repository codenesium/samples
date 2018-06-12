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

                Task<List<ApiMachinePolicyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiMachinePolicyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>0191d1a1ef41b14dcc2da06d12ce8904</Hash>
</Codenesium>*/