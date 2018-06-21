using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLMachinePolicyMapper
        {
                BOMachinePolicy MapModelToBO(
                        string id,
                        ApiMachinePolicyRequestModel model);

                ApiMachinePolicyResponseModel MapBOToModel(
                        BOMachinePolicy boMachinePolicy);

                List<ApiMachinePolicyResponseModel> MapBOToModel(
                        List<BOMachinePolicy> items);
        }
}

/*<Codenesium>
    <Hash>93d4236f279e65c26da5bd7c1f8c9c5e</Hash>
</Codenesium>*/