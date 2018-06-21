using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>da6caa975b3925e301693687276aea72</Hash>
</Codenesium>*/