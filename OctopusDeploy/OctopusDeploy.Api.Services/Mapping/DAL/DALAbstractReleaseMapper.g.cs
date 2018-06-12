using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractReleaseMapper
        {
                public virtual Release MapBOToEF(
                        BORelease bo)
                {
                        Release efRelease = new Release();

                        efRelease.SetProperties(
                                bo.Assembled,
                                bo.ChannelId,
                                bo.Id,
                                bo.JSON,
                                bo.ProjectDeploymentProcessSnapshotId,
                                bo.ProjectId,
                                bo.ProjectVariableSetSnapshotId,
                                bo.Version);
                        return efRelease;
                }

                public virtual BORelease MapEFToBO(
                        Release ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BORelease();

                        bo.SetProperties(
                                ef.Id,
                                ef.Assembled,
                                ef.ChannelId,
                                ef.JSON,
                                ef.ProjectDeploymentProcessSnapshotId,
                                ef.ProjectId,
                                ef.ProjectVariableSetSnapshotId,
                                ef.Version);
                        return bo;
                }

                public virtual List<BORelease> MapEFToBO(
                        List<Release> records)
                {
                        List<BORelease> response = new List<BORelease>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e43cb06302892de49da10858061a5370</Hash>
</Codenesium>*/