using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractDeploymentMapper
        {
                public virtual BODeployment MapModelToBO(
                        string id,
                        ApiDeploymentRequestModel model
                        )
                {
                        BODeployment boDeployment = new BODeployment();
                        boDeployment.SetProperties(
                                id,
                                model.ChannelId,
                                model.Created,
                                model.DeployedBy,
                                model.DeployedToMachineIds,
                                model.EnvironmentId,
                                model.JSON,
                                model.Name,
                                model.ProjectGroupId,
                                model.ProjectId,
                                model.ReleaseId,
                                model.TaskId,
                                model.TenantId);
                        return boDeployment;
                }

                public virtual ApiDeploymentResponseModel MapBOToModel(
                        BODeployment boDeployment)
                {
                        var model = new ApiDeploymentResponseModel();

                        model.SetProperties(boDeployment.ChannelId, boDeployment.Created, boDeployment.DeployedBy, boDeployment.DeployedToMachineIds, boDeployment.EnvironmentId, boDeployment.Id, boDeployment.JSON, boDeployment.Name, boDeployment.ProjectGroupId, boDeployment.ProjectId, boDeployment.ReleaseId, boDeployment.TaskId, boDeployment.TenantId);

                        return model;
                }

                public virtual List<ApiDeploymentResponseModel> MapBOToModel(
                        List<BODeployment> items)
                {
                        List<ApiDeploymentResponseModel> response = new List<ApiDeploymentResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>610eb64d93e89a26d8823449e7ac3404</Hash>
</Codenesium>*/