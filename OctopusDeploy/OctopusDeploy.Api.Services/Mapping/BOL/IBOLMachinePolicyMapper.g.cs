using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>cdb18528606d847700ab5fb7d33b0f29</Hash>
</Codenesium>*/