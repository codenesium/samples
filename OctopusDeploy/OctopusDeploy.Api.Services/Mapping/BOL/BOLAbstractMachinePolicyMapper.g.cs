using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractMachinePolicyMapper
        {
                public virtual BOMachinePolicy MapModelToBO(
                        string id,
                        ApiMachinePolicyRequestModel model
                        )
                {
                        BOMachinePolicy boMachinePolicy = new BOMachinePolicy();

                        boMachinePolicy.SetProperties(
                                id,
                                model.IsDefault,
                                model.JSON,
                                model.Name);
                        return boMachinePolicy;
                }

                public virtual ApiMachinePolicyResponseModel MapBOToModel(
                        BOMachinePolicy boMachinePolicy)
                {
                        var model = new ApiMachinePolicyResponseModel();

                        model.SetProperties(boMachinePolicy.Id, boMachinePolicy.IsDefault, boMachinePolicy.JSON, boMachinePolicy.Name);

                        return model;
                }

                public virtual List<ApiMachinePolicyResponseModel> MapBOToModel(
                        List<BOMachinePolicy> items)
                {
                        List<ApiMachinePolicyResponseModel> response = new List<ApiMachinePolicyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>020394fd9772f3e3f0d7800fc2e4b5a9</Hash>
</Codenesium>*/