using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractProjectMapper
        {
                public virtual Project MapBOToEF(
                        BOProject bo)
                {
                        Project efProject = new Project();

                        efProject.SetProperties(
                                bo.AutoCreateRelease,
                                bo.DataVersion,
                                bo.DeploymentProcessId,
                                bo.DiscreteChannelRelease,
                                bo.Id,
                                bo.IncludedLibraryVariableSetIds,
                                bo.IsDisabled,
                                bo.JSON,
                                bo.LifecycleId,
                                bo.Name,
                                bo.ProjectGroupId,
                                bo.Slug,
                                bo.VariableSetId);
                        return efProject;
                }

                public virtual BOProject MapEFToBO(
                        Project ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProject();

                        bo.SetProperties(
                                ef.Id,
                                ef.AutoCreateRelease,
                                ef.DataVersion,
                                ef.DeploymentProcessId,
                                ef.DiscreteChannelRelease,
                                ef.IncludedLibraryVariableSetIds,
                                ef.IsDisabled,
                                ef.JSON,
                                ef.LifecycleId,
                                ef.Name,
                                ef.ProjectGroupId,
                                ef.Slug,
                                ef.VariableSetId);
                        return bo;
                }

                public virtual List<BOProject> MapEFToBO(
                        List<Project> records)
                {
                        List<BOProject> response = new List<BOProject>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>23bc77b827d479f278881914be11edde</Hash>
</Codenesium>*/