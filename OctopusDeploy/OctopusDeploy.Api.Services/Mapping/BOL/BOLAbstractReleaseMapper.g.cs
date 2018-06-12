using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractReleaseMapper
        {
                public virtual BORelease MapModelToBO(
                        string id,
                        ApiReleaseRequestModel model
                        )
                {
                        BORelease boRelease = new BORelease();

                        boRelease.SetProperties(
                                id,
                                model.Assembled,
                                model.ChannelId,
                                model.JSON,
                                model.ProjectDeploymentProcessSnapshotId,
                                model.ProjectId,
                                model.ProjectVariableSetSnapshotId,
                                model.Version);
                        return boRelease;
                }

                public virtual ApiReleaseResponseModel MapBOToModel(
                        BORelease boRelease)
                {
                        var model = new ApiReleaseResponseModel();

                        model.SetProperties(boRelease.Assembled, boRelease.ChannelId, boRelease.Id, boRelease.JSON, boRelease.ProjectDeploymentProcessSnapshotId, boRelease.ProjectId, boRelease.ProjectVariableSetSnapshotId, boRelease.Version);

                        return model;
                }

                public virtual List<ApiReleaseResponseModel> MapBOToModel(
                        List<BORelease> items)
                {
                        List<ApiReleaseResponseModel> response = new List<ApiReleaseResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>99a41786e14f32fe812329b2e6622efc</Hash>
</Codenesium>*/