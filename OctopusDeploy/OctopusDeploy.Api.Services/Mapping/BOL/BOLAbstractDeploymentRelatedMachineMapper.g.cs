using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractDeploymentRelatedMachineMapper
        {
                public virtual BODeploymentRelatedMachine MapModelToBO(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel model
                        )
                {
                        BODeploymentRelatedMachine boDeploymentRelatedMachine = new BODeploymentRelatedMachine();

                        boDeploymentRelatedMachine.SetProperties(
                                id,
                                model.DeploymentId,
                                model.MachineId);
                        return boDeploymentRelatedMachine;
                }

                public virtual ApiDeploymentRelatedMachineResponseModel MapBOToModel(
                        BODeploymentRelatedMachine boDeploymentRelatedMachine)
                {
                        var model = new ApiDeploymentRelatedMachineResponseModel();

                        model.SetProperties(boDeploymentRelatedMachine.DeploymentId, boDeploymentRelatedMachine.Id, boDeploymentRelatedMachine.MachineId);

                        return model;
                }

                public virtual List<ApiDeploymentRelatedMachineResponseModel> MapBOToModel(
                        List<BODeploymentRelatedMachine> items)
                {
                        List<ApiDeploymentRelatedMachineResponseModel> response = new List<ApiDeploymentRelatedMachineResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b347431f078d2eb0ab70d8e28777729b</Hash>
</Codenesium>*/