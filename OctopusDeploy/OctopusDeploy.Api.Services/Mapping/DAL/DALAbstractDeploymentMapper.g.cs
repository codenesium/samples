using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractDeploymentMapper
        {
                public virtual Deployment MapBOToEF(
                        BODeployment bo)
                {
                        Deployment efDeployment = new Deployment();
                        efDeployment.SetProperties(
                                bo.ChannelId,
                                bo.Created,
                                bo.DeployedBy,
                                bo.DeployedToMachineIds,
                                bo.EnvironmentId,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.ProjectGroupId,
                                bo.ProjectId,
                                bo.ReleaseId,
                                bo.TaskId,
                                bo.TenantId);
                        return efDeployment;
                }

                public virtual BODeployment MapEFToBO(
                        Deployment ef)
                {
                        var bo = new BODeployment();

                        bo.SetProperties(
                                ef.Id,
                                ef.ChannelId,
                                ef.Created,
                                ef.DeployedBy,
                                ef.DeployedToMachineIds,
                                ef.EnvironmentId,
                                ef.JSON,
                                ef.Name,
                                ef.ProjectGroupId,
                                ef.ProjectId,
                                ef.ReleaseId,
                                ef.TaskId,
                                ef.TenantId);
                        return bo;
                }

                public virtual List<BODeployment> MapEFToBO(
                        List<Deployment> records)
                {
                        List<BODeployment> response = new List<BODeployment>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>d38eeaa27d06af2f1d28fab8083f5423</Hash>
</Codenesium>*/