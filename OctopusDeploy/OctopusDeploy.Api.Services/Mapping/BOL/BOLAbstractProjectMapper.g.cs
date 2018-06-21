using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class BOLAbstractProjectMapper
        {
                public virtual BOProject MapModelToBO(
                        string id,
                        ApiProjectRequestModel model
                        )
                {
                        BOProject boProject = new BOProject();
                        boProject.SetProperties(
                                id,
                                model.AutoCreateRelease,
                                model.DataVersion,
                                model.DeploymentProcessId,
                                model.DiscreteChannelRelease,
                                model.IncludedLibraryVariableSetIds,
                                model.IsDisabled,
                                model.JSON,
                                model.LifecycleId,
                                model.Name,
                                model.ProjectGroupId,
                                model.Slug,
                                model.VariableSetId);
                        return boProject;
                }

                public virtual ApiProjectResponseModel MapBOToModel(
                        BOProject boProject)
                {
                        var model = new ApiProjectResponseModel();

                        model.SetProperties(boProject.AutoCreateRelease, boProject.DataVersion, boProject.DeploymentProcessId, boProject.DiscreteChannelRelease, boProject.Id, boProject.IncludedLibraryVariableSetIds, boProject.IsDisabled, boProject.JSON, boProject.LifecycleId, boProject.Name, boProject.ProjectGroupId, boProject.Slug, boProject.VariableSetId);

                        return model;
                }

                public virtual List<ApiProjectResponseModel> MapBOToModel(
                        List<BOProject> items)
                {
                        List<ApiProjectResponseModel> response = new List<ApiProjectResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>89668ed7e8392c8b4bdbdcd93c965f1b</Hash>
</Codenesium>*/