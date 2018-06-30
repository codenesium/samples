using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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

                        model.SetProperties(boDeploymentRelatedMachine.Id, boDeploymentRelatedMachine.DeploymentId, boDeploymentRelatedMachine.MachineId);

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
    <Hash>e5b57c72943996adc2248e305aecda24</Hash>
</Codenesium>*/