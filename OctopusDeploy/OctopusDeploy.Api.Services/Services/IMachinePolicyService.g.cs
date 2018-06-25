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

                Task<ApiMachinePolicyResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>3798e37b899bfc6f43e65bf9720ad3cd</Hash>
</Codenesium>*/